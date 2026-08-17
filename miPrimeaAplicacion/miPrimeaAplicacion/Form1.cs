using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miPrimeaAplicacion {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        /*
          Metros, Cm, Pulgadas, Pies, Varas, Yardas, Km,Millas
         */
        String[][] etiquetas = {
            new string[]{"Metros", "Cm", "Pulgadas", "Pies", "Varas", "Yardas", "Km","Millas"}, //Longitud
            new string[]{"Dolar", "Quetzal","Lempira","Cordobas","Colon CR"}//Monedas
        };
        Double[][] valores = {
            new double[]{1, 100, 39.3701, 3.28084, 1.1963, 1.09361, 0.001, 0.000621371},
            new double[]{1, 7.63, 26.81, 36.80, 449.23 }
        };
        private void Form1_Load(object sender, EventArgs e) {

        }
        private void btnCalcular_Click(object sender, EventArgs e) {
            int de = cboDe.SelectedIndex, a = cboA.SelectedIndex, opcion = cboOpciones.SelectedIndex;
            double cantidad = Double.Parse(txtCantidad.Text);

            double respuesta = valores[opcion][a] / valores[opcion][de] * cantidad;

            lblRespuesta.Text = respuesta.ToString();
        }

        private void cboOpciones_SelectedIndexChanged(object sender, EventArgs e) {
            //Limpiamos los valores anteriores
            cboDe.Items.Clear();
            cboA.Items.Clear();

            //Asignamos los nuevos valores
            int opcion = cboOpciones.SelectedIndex;
            cboDe.Items.AddRange(etiquetas[opcion]);
            cboA.Items.AddRange(etiquetas[opcion]);
        }
    }
}
