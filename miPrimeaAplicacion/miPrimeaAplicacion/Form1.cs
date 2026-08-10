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
                int tabla = int.Parse(txtTabla.Text), i=1;
                String msg = "";
                do {
                    msg += $"{tabla} x {i} = {tabla * i}\n";
                    i++; // i= i+1
                } while (i <= 10);
                lblRespuesta.Text = msg;
            } catch(Exception) {
                lblRespuesta.Text = "Por favo ingrese la edad en numero entero";
            }
        }
    }
}
