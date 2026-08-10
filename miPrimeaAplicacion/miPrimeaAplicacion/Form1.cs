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
                String msg = "Ingresa tu edad";

                //if ternario
                msg = edad < 0 ? "Edad no valida" : 
                    edad <= 2 ? "Eres un bebe" : 
                    edad < 12 ? "Eres un niño" : 
                    edad <= 17 ? "Eres un adolescente" : 
                    edad < 65 ? "Eres un adulto" : 
                    edad <= 80 ? "Eres un adulto mayor" : 
                    edad <= 130 ? "Larga vidad" : "Edad no valida";

                lblRespuesta.Text = msg;
            } catch(Exception) {
                lblRespuesta.Text = "Por favo ingrese la edad en numero entero";
            }
        }
    }
}
