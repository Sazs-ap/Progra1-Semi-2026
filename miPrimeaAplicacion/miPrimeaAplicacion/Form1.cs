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
        Double[] valores = {1, 100, 39.3701, 3.28084, 1.1963, 1.09361, 0.001, 0.000621371};
        private void Form1_Load(object sender, EventArgs e) {

        }
        private void btnCalcular_Click(object sender, EventArgs e) {
            int de = cboDe.SelectedIndex, a = cboA.SelectedIndex;
            double cantidad = Double.Parse(txtCantidad.Text);

            double respuesta = valores[a] / valores[de] * cantidad;

            lblRespuesta.Text = respuesta.ToString();
        }
    }
}
