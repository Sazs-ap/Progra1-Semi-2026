using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    // Versión para el formulario dibujado en el diseñador.
    // Los botones y tarjetas se dibujan arrastrándolos; este archivo solo tiene la lógica.
    // Cada botón exporta un PDF usando la impresora "Microsoft Print to PDF" de Windows.
    public partial class frmReportes : Form
    {
        // Usa la misma cadena de conexión que tus otros formularios.
        private readonly string cadenaConexion = "Server=(localdb)\\MSSQLLocalDB; Database=SistemaDeRegistroMaferrer; Trusted_Connection=True;";

        private static readonly CultureInfo Us = new CultureInfo("en-US");

        public frmReportes()
        {
            InitializeComponent();

            // Los eventos se conectan aquí: no hagas doble clic en los botones del diseñador.
            btnPdfHabitantes.Click += (s, e) => ExportarHabitantes();
            btnPdfAportaciones.Click += (s, e) => ExportarAportacionesMes();
            btnPdfSolventes.Click += (s, e) => ExportarSolventesPendientes();
            btnPdfVisitas.Click += (s, e) => Proximamente("Visitas");
            btnPdfIncidentes.Click += (s, e) => Proximamente("Incidentes");
        }

        private void Proximamente(string modulo)
        {
            MessageBox.Show("El reporte de " + modulo + " estará disponible cuando exista ese módulo.", "Próximamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------- LOS REPORTES ----------
        private void ExportarHabitantes()
        {
            ExportarPdf(
                "Lista de habitantes",
                "SELECT nombre AS Nombre, [código] AS Casa, direccion AS [Dirección], telefono AS [Teléfono] " +
                "FROM dbo.habitantes ORDER BY nombre",
                "lista_habitantes",
                dt => "Total de habitantes: " + dt.Rows.Count);
        }

        private void ExportarAportacionesMes()
        {
            string mes = new CultureInfo("es-ES").DateTimeFormat.GetMonthName(DateTime.Today.Month);
            mes = char.ToUpper(mes[0]) + mes.Substring(1);

            ExportarPdf(
                "Aportaciones de " + mes + " " + DateTime.Today.Year,
                @"SELECT CONVERT(varchar(10), a.fecha, 103) AS Fecha,
                         h.nombre AS Habitante,
                         a.concepto AS Concepto,
                         a.monto AS Monto,
                         ISNULL(a.numComprobante, '') AS [N.° Comprobante]
                  FROM dbo.aportaciones a
                  INNER JOIN dbo.habitantes h ON h.idHabitantes = a.idHabitantes
                  WHERE a.estado = 'Solvente'
                    AND YEAR(a.fecha) = YEAR(GETDATE())
                    AND MONTH(a.fecha) = MONTH(GETDATE())
                  ORDER BY a.fecha, h.nombre",
                "aportaciones_mes",
                dt =>
                {
                    decimal total = 0;
                    foreach (DataRow fila in dt.Rows) total += Convert.ToDecimal(fila["Monto"]);
                    return "Aportaciones: " + dt.Rows.Count + "     Total recaudado: " + total.ToString("C2", Us);
                });
        }

        private void ExportarSolventesPendientes()
        {
            ExportarPdf(
                "Habitantes solventes y pendientes",
                @"SELECT h.nombre AS Habitante,
                         h.[código] AS Casa,
                         CASE WHEN SUM(CASE WHEN a.estado = 'Pendiente' THEN 1 ELSE 0 END) > 0
                              THEN 'Pendiente' ELSE 'Solvente' END AS Estado,
                         SUM(CASE WHEN a.estado = 'Pendiente' THEN 1 ELSE 0 END) AS [Pagos pendientes],
                         ISNULL(SUM(CASE WHEN a.estado = 'Pendiente' THEN a.monto END), 0) AS [Monto adeudado]
                  FROM dbo.habitantes h
                  LEFT JOIN dbo.aportaciones a ON a.idHabitantes = h.idHabitantes
                  GROUP BY h.idHabitantes, h.nombre, h.[código]
                  ORDER BY SUM(CASE WHEN a.estado = 'Pendiente' THEN 1 ELSE 0 END) DESC, h.nombre",
                "solventes_pendientes",
                dt =>
                {
                    int pendientes = 0;
                    decimal adeudado = 0;
                    foreach (DataRow fila in dt.Rows)
                    {
                        if (fila["Estado"].ToString() == "Pendiente") pendientes++;
                        adeudado += Convert.ToDecimal(fila["Monto adeudado"]);
                    }
                    return "Solventes: " + (dt.Rows.Count - pendientes)
                         + "     Pendientes: " + pendientes
                         + "     Total adeudado: " + adeudado.ToString("C2", Us);
                });
        }

        // ---------- EXPORTAR ----------
        private void ExportarPdf(string titulo, string sql, string nombreBase, Func<DataTable, string> resumen)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    new SqlDataAdapter(sql, con).Fill(dt);
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para este reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!ImpresoraPdfDisponible())
                {
                    MessageBox.Show("No se encontró la impresora \"Microsoft Print to PDF\" en este equipo.\n" +
                                    "Actívala en Windows (Configuración → Bluetooth y dispositivos → Impresoras) y vuelve a intentar.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ruta;
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Documento PDF (*.pdf)|*.pdf";
                    sfd.FileName = nombreBase + "_" + DateTime.Today.ToString("yyyyMMdd") + ".pdf";
                    if (sfd.ShowDialog(this) != DialogResult.OK) return;
                    ruta = sfd.FileName;
                }

                if (File.Exists(ruta)) File.Delete(ruta);

                GenerarPdf(titulo, dt, resumen(dt), ruta);

                // El archivo lo escribe Windows en segundo plano: se espera unos segundos
                for (int i = 0; i < 50 && !File.Exists(ruta); i++) Thread.Sleep(100);

                if (File.Exists(ruta))
                    MessageBox.Show("Reporte guardado en:\n" + ruta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("El reporte se envió a PDF, pero el archivo aún no aparece. Revisa la carpeta elegida en unos segundos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool ImpresoraPdfDisponible()
        {
            foreach (string impresora in PrinterSettings.InstalledPrinters)
            {
                if (impresora == "Microsoft Print to PDF") return true;
            }
            return false;
        }

        // Dibuja el reporte como tabla con paginación y lo manda al PDF
        private void GenerarPdf(string titulo, DataTable dt, string resumen, string ruta)
        {
            PrintDocument pd = new PrintDocument();
            pd.DocumentName = titulo;
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = ruta;
            pd.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);

            float[] anchos = null;
            bool[] esMoneda = null;
            int indiceFila = 0;
            int pagina = 0;

            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;
                Rectangle m = e.MarginBounds;
                pagina++;

                using (Font fTitulo = new Font("Segoe UI", 16F, FontStyle.Bold))
                using (Font fNormal = new Font("Segoe UI", 9.5F))
                using (Font fNegrita = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (Font fPequena = new Font("Segoe UI", 8.5F))
                using (SolidBrush bEncabezado = new SolidBrush(Color.FromArgb(44, 62, 80)))
                using (SolidBrush bAlterna = new SolidBrush(Color.FromArgb(244, 246, 249)))
                using (StringFormat sfIzq = new StringFormat())
                using (StringFormat sfDer = new StringFormat())
                {
                    sfIzq.Trimming = StringTrimming.EllipsisCharacter;
                    sfIzq.FormatFlags = StringFormatFlags.NoWrap;
                    sfIzq.LineAlignment = StringAlignment.Center;

                    sfDer.Trimming = StringTrimming.EllipsisCharacter;
                    sfDer.FormatFlags = StringFormatFlags.NoWrap;
                    sfDer.LineAlignment = StringAlignment.Center;
                    sfDer.Alignment = StringAlignment.Far;

                    if (anchos == null)
                    {
                        anchos = CalcularAnchos(g, dt, fNormal, fNegrita, m.Width);
                        esMoneda = new bool[dt.Columns.Count];
                        for (int c = 0; c < dt.Columns.Count; c++)
                            esMoneda[c] = dt.Columns[c].DataType == typeof(decimal);
                    }

                    float y = m.Top;

                    if (pagina == 1)
                    {
                        g.DrawString(titulo, fTitulo, Brushes.Black, m.Left, y);
                        y += fTitulo.GetHeight(g) + 2;
                        g.DrawString("Comunidad Masferrer - Registro comunitario", fPequena, Brushes.Gray, m.Left, y);
                        y += fPequena.GetHeight(g);
                        g.DrawString("Generado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fPequena, Brushes.Gray, m.Left, y);
                        y += fPequena.GetHeight(g) + 12;
                    }

                    float alto = fNormal.GetHeight(g) + 8;

                    // Encabezado de la tabla (se repite en cada página)
                    g.FillRectangle(bEncabezado, m.Left, y, m.Width, alto);
                    float x = m.Left;
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        RectangleF celda = new RectangleF(x + 4, y, anchos[c] - 8, alto);
                        g.DrawString(dt.Columns[c].ColumnName, fNegrita, Brushes.White, celda, esMoneda[c] ? sfDer : sfIzq);
                        x += anchos[c];
                    }
                    y += alto;

                    // Filas
                    while (indiceFila < dt.Rows.Count)
                    {
                        if (y + alto > m.Bottom - 20)
                        {
                            e.HasMorePages = true;
                            break;
                        }

                        if (indiceFila % 2 == 1) g.FillRectangle(bAlterna, m.Left, y, m.Width, alto);

                        x = m.Left;
                        for (int c = 0; c < dt.Columns.Count; c++)
                        {
                            RectangleF celda = new RectangleF(x + 4, y, anchos[c] - 8, alto);
                            g.DrawString(FormatearCelda(dt.Rows[indiceFila][c]), fNormal, Brushes.Black, celda, esMoneda[c] ? sfDer : sfIzq);
                            x += anchos[c];
                        }

                        y += alto;
                        indiceFila++;
                    }

                    // Resumen al final
                    if (!e.HasMorePages)
                    {
                        if (y + alto * 2 > m.Bottom)
                        {
                            e.HasMorePages = true; // el resumen pasa a la página siguiente
                        }
                        else
                        {
                            y += 10;
                            g.DrawLine(Pens.Gray, m.Left, y, m.Right, y);
                            y += 6;
                            g.DrawString(resumen, fNegrita, Brushes.Black, m.Left, y);
                        }
                    }

                    g.DrawString("Página " + pagina, fPequena, Brushes.Gray, m.Right - 60, m.Bottom + 6);
                }
            };

            pd.Print();
        }

        private static float[] CalcularAnchos(Graphics g, DataTable dt, Font normal, Font negrita, int total)
        {
            int n = dt.Columns.Count;
            float[] w = new float[n];
            float suma = 0;

            for (int c = 0; c < n; c++)
            {
                float max = g.MeasureString(dt.Columns[c].ColumnName, negrita).Width;
                int limite = Math.Min(dt.Rows.Count, 200);

                for (int r = 0; r < limite; r++)
                {
                    float t = g.MeasureString(FormatearCelda(dt.Rows[r][c]), normal).Width;
                    if (t > max) max = t;
                }

                w[c] = Math.Min(max + 16, 320);
                suma += w[c];
            }

            float factor = total / suma;
            for (int c = 0; c < n; c++) w[c] *= factor;
            return w;
        }

        private static string FormatearCelda(object valor)
        {
            if (valor == null || valor == DBNull.Value) return "";
            if (valor is decimal) return ((decimal)valor).ToString("$#,##0.00", Us);
            if (valor is DateTime) return ((DateTime)valor).ToString("dd/MM/yyyy");
            return valor.ToString();
        }

        // Manejadores vacíos que el diseñador (Designer.cs) espera encontrar
        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void lblTituloHabitantes_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlInicio_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}