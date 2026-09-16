using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_estadistico
{
    public partial class Form1 : Form
    {
        // ==========================================
        // DATOS DE LOS 20 COMPAÑEROS
        // ==========================================

        private List<double> edades = new List<double>
        {
            17, 17, 18, 18, 18, 18, 18, 18, 18, 18,
            18, 18, 18, 19, 19, 19, 19, 19, 19, 20
        };

        private List<double> tiempoTraslado = new List<double>
        {
            15, 15, 20, 20, 25, 25, 30, 30, 30, 30,
            35, 35, 40, 40, 60, 60, 60, 60, 60, 70
        };

        private List<double> horasTelefono = new List<double>
        {
            4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 5.0,
            6.0, 6.0, 6.0, 6.0, 6.0, 6.0,
            7.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0
        };


        // ==========================================
        // CONSTRUCTOR
        // ==========================================

        public Form1()
        {
            InitializeComponent();

            // Agregar opciones al ComboBox
            cmbDataset.Items.AddRange(new string[]
            {
                "Edades",
                "Tiempo de traslado",
                "Horas de uso del teléfono"
            });

            // Seleccionar Edades por defecto
            cmbDataset.SelectedIndex = 0;

            // Crear columnas de la tabla
            dgvFrecuencia.Columns.Add("colValor", "Valor");
            dgvFrecuencia.Columns.Add("colFrecuencia", "Frecuencia");

            // Quitar la fila vacía de "agregar nuevo" y los encabezados de fila
            dgvFrecuencia.AllowUserToAddRows = false;
            dgvFrecuencia.RowHeadersVisible = false;
            dgvFrecuencia.Columns["colValor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFrecuencia.Columns["colFrecuencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Estilo visual de la tabla
            dgvFrecuencia.ReadOnly = true;
            dgvFrecuencia.AllowUserToResizeRows = false;
            dgvFrecuencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFrecuencia.MultiSelect = false;
            dgvFrecuencia.BackgroundColor = System.Drawing.Color.White;
            dgvFrecuencia.BorderStyle = BorderStyle.None;
            dgvFrecuencia.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFrecuencia.GridColor = System.Drawing.Color.LightGray;

            // Encabezados centrados y con color de fondo
            dgvFrecuencia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFrecuencia.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            dgvFrecuencia.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgvFrecuencia.Font, System.Drawing.FontStyle.Bold);
            dgvFrecuencia.EnableHeadersVisualStyles = false;
            dgvFrecuencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Celdas centradas y filas alternadas
            dgvFrecuencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFrecuencia.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        }


        // ==========================================
        // BOTÓN CALCULAR
        // ==========================================

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Obtener los datos seleccionados
            List<double> datos = ObtenerDatasetSeleccionado();
            string unidad = ObtenerUnidad();

            // Calcular medidas estadísticas
            double media = CalcularMedia(datos);
            double mediana = CalcularMediana(datos);
            List<double> moda = CalcularModa(datos);

            double varianza = CalcularVarianza(datos, media);
            double desviacion = Math.Sqrt(varianza);

            double rango = datos.Max() - datos.Min();


            // Mostrar resultados (con la unidad correspondiente)
            txtResultados.Text =
                $"Media: {media.ToString("0.##")} {unidad}\r\n" +
                $"Mediana: {mediana.ToString("0.##")} {unidad}\r\n" +
                $"Moda: {string.Join(", ", moda.Select(m => m.ToString("0.##")))} {unidad}\r\n" +
                $"Varianza: {varianza.ToString("0.##")}\r\n" +
                $"Desviación estándar: {desviacion.ToString("0.##")} {unidad}\r\n" +
                $"Desviación típica: {desviacion.ToString("0.##")} {unidad}\r\n" +
                $"Rango: {rango.ToString("0.##")} {unidad}";

            // Actualizar el encabezado de la columna según el dataset
            dgvFrecuencia.Columns["colValor"].HeaderText = $"Valor ({unidad})";

            // Mostrar tabla de frecuencias
            MostrarFrecuencias(datos);
        }


        // ==========================================
        // SELECCIONAR CONJUNTO DE DATOS
        // ==========================================

        private List<double> ObtenerDatasetSeleccionado()
        {
            switch (cmbDataset.SelectedItem.ToString())
            {
                case "Tiempo de traslado":
                    return tiempoTraslado;

                case "Horas de uso del teléfono":
                    return horasTelefono;

                default:
                    return edades;
            }
        }


        // ==========================================
        // OBTENER ETIQUETA / UNIDAD DEL DATASET
        // ==========================================

        private string ObtenerUnidad()
        {
            switch (cmbDataset.SelectedItem.ToString())
            {
                case "Tiempo de traslado":
                    return "min";

                case "Horas de uso del teléfono":
                    return "hrs";

                default:
                    return "años";
            }
        }


        // ==========================================
        // CALCULAR MEDIA
        // ==========================================

        private double CalcularMedia(List<double> datos)
        {
            return datos.Sum() / datos.Count;
        }


        // ==========================================
        // CALCULAR MEDIANA
        // ==========================================

        private double CalcularMediana(List<double> datos)
        {
            // Ordenar los datos
            List<double> ordenados = datos.OrderBy(x => x).ToList();

            int n = ordenados.Count;

            // Si la cantidad de datos es par
            if (n % 2 == 0)
            {
                return (ordenados[n / 2 - 1] + ordenados[n / 2]) / 2.0;
            }
            else
            {
                // Si la cantidad de datos es impar
                return ordenados[n / 2];
            }
        }


        // ==========================================
        // CALCULAR MODA
        // ==========================================

        private List<double> CalcularModa(List<double> datos)
        {
            var frecuencias = datos
                .GroupBy(valor => valor)
                .Select(grupo => new
                {
                    Valor = grupo.Key,
                    Cantidad = grupo.Count()
                })
                .ToList();

            // Buscar la frecuencia más alta
            int maxFrecuencia = frecuencias.Max(f => f.Cantidad);

            // Obtener el o los valores que tengan
            // la frecuencia más alta
            return frecuencias
                .Where(f => f.Cantidad == maxFrecuencia)
                .Select(f => f.Valor)
                .ToList();
        }


        // ==========================================
        // CALCULAR VARIANZA
        // ==========================================

        private double CalcularVarianza(List<double> datos, double media)
        {
            double sumaCuadrados = datos.Sum(
                valor => Math.Pow(valor - media, 2)
            );

            // Varianza poblacional
            return sumaCuadrados / datos.Count;
        }


        // ==========================================
        // MOSTRAR TABLA DE FRECUENCIAS
        // ==========================================

        private void MostrarFrecuencias(List<double> datos)
        {
            // Limpiar filas anteriores
            dgvFrecuencia.Rows.Clear();

            // Agrupar y contar frecuencias
            var frecuencias = datos
                .GroupBy(valor => valor)
                .OrderBy(grupo => grupo.Key)
                .Select(grupo => new
                {
                    Valor = grupo.Key,
                    Cantidad = grupo.Count()
                });


            // Agregar los datos a la tabla
            foreach (var item in frecuencias)
            {
                dgvFrecuencia.Rows.Add(
                    item.Valor.ToString("0.##"),
                    item.Cantidad
                );
            }
        }


        // ==========================================
        // EVENTO DEL DATAGRIDVIEW
        // ==========================================

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }


        // ==========================================
        // EVENTO LOAD DEL FORMULARIO
        // ==========================================

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtResultados_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbDataset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}