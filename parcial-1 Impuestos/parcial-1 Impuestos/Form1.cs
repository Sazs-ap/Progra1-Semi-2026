using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parcial_1_Impuestos
{
    public partial class Form1 : Form
    {
        private const double LIMITE_BASE = 1000.0;
        private const double AJUSTE_RANGO = 1000.01;
        private const double TASA_ADICIONAL = 3.0;
        private const double VALOR_FIJO = 3.0;

        public Form1()
        {
            InitializeComponent();

            // El resultado no debe poder editarse manualmente
            txtImpuestoPagar.ReadOnly = true;
        }

        // BOTÓN CALCULAR
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!ObtenerMontoValido(out double montoActividad))
                return;

            double impuestoCalculado = CalcularImpuesto(montoActividad);

            txtImpuestoPagar.Text = impuestoCalculado.ToString("C2", CultureInfo.GetCultureInfo("es-SV"));
        }

        // BOTÓN VER CÁLCULO
        private void btnVerDesarrollo_Click(object sender, EventArgs e)
        {
            if (!ObtenerMontoValido(out double montoActividad))
                return;

            if (montoActividad <= LIMITE_BASE)
            {
                MessageBox.Show(
                    $"Actividad económica: {montoActividad:0.00}\n\n" +
                    $"Al ser menor o igual a {LIMITE_BASE:0.00}, se aplica valor fijo.\n\n" +
                    $"IMPUESTO A PAGAR: ${VALOR_FIJO:0.00}",
                    "Detalle del cálculo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            double excedente = montoActividad - AJUSTE_RANGO;
            double impuestoCalculado = CalcularImpuesto(montoActividad);

            string mensaje =
                "Cálculo detallado del impuesto\n\n" +
                $"Ejemplo: una actividad económica de ${montoActividad:0.00} " +
                $"genera un pago de ${impuestoCalculado:0.00}\n\n" +
                $"Paso 1 (excedente): {montoActividad:0.00} - {AJUSTE_RANGO:0.00} = {excedente:0.00}\n" +
                $"Paso 2 (fórmula): ({excedente:0.00} / 1000) * {TASA_ADICIONAL:0.00} + {VALOR_FIJO:0.00} = ${impuestoCalculado:0.00}";

            MessageBox.Show(
                mensaje,
                "Resultado del cálculo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Valida el texto ingresado y lo convierte a monto
        private bool ObtenerMontoValido(out double monto)
        {
            monto = 0;

            if (!double.TryParse(txtMontoActividad.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out monto))
            {
                MessageBox.Show(
                    "Ingrese un monto numérico válido.",
                    "Dato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (monto < 0)
            {
                MessageBox.Show(
                    "El monto de la actividad económica no puede ser negativo.",
                    "Dato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Aplica la fórmula del impuesto según el rango del monto
        private double CalcularImpuesto(double monto)
        {
            if (monto <= LIMITE_BASE)
                return VALOR_FIJO;

            double excedente = monto - AJUSTE_RANGO;
            return (excedente / 1000) * TASA_ADICIONAL + VALOR_FIJO;
        }

        // EVENTOS DEL DISEÑADOR (sin lógica)
        private void lblMontoActividad_Click(object sender, EventArgs e) { }
        private void txtMontoActividad_TextChanged(object sender, EventArgs e) { }
        private void txtImpuestoPagar_TextChanged(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMontoActividad.Clear();
            txtImpuestoPagar.Clear();

            txtMontoActividad.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
