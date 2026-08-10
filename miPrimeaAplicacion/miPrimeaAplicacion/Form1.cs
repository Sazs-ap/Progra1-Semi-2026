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
        private void Form1_Load(object sender, EventArgs e) {

        }
        private void btnCalcular_Click(object sender, EventArgs e) {
            try {
                int edad = int.Parse(txtEdad.Text);
                if (edad < 0) {
                    lblRespuesta.Text = "Edad no valida";
                } else if (edad <= 2) {
                    lblRespuesta.Text = "Eres un bebe";
                } else if (edad < 12) {
                    lblRespuesta.Text = "Eres un niño";
                } else if (edad <= 17) {
                    lblRespuesta.Text = "Eres un adolescente";
                } else if (edad < 65) {
                    lblRespuesta.Text = "Eres un adulto";
                } else if (edad <= 80) {
                    lblRespuesta.Text = "Eres un adulto mayor";
                } else if (edad <= 130) {
                    lblRespuesta.Text = "Larga vidad";
                } else {
                    lblRespuesta.Text = "Edad no valida";
                }
            }catch(Exception) {
                lblRespuesta.Text = "Por favo ingrese la edad en numero entero";
            }
        }
    }
}
