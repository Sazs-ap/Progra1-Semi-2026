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
            //Tarea: Agrega la opcion de modulo, obtener el residuo de la division de num1 entre num2

            double num1 =0, num2=0, resultado=0, indexOpcion=0;
            num1 = Double.Parse(txtNum1.Text); //txtNum1.Text > cadena= "5" => 5.0
            num2 = Double.Parse(txtNum2.Text);

            /*if( rdbSuma.Checked) {
                resultado = num1 + num2;
            }
            if (rdbResta.Checked) {
                resultado = num1 - num2;
            }
            if (rdbMultiplicacion.Checked) {
                resultado = num1 * num2;
            }
            if (rdbDivision.Checked) {
                resultado = num1 / num2;
            }
            if (rdbExponente.Checked) {
                resultado = Math.Pow(num1, num2);//elevar num1 a la potencia num2
            }
            if (rdbRaiz.Checked) {
                resultado = Math.Pow(num1, 1/num2);//raiz num2 de num1
            }
            if (rdbFactorial.Checked) { //5*4*3*2*1=120
                resultado=1;
                for (int i = 1; i <= num1; i++) {
                    resultado = resultado*i;
                }
            }*/
            indexOpcion = cboOpciones.SelectedIndex;
            switch (indexOpcion) {
                case 0: //Suma
                    resultado = num1 + num2;
                    break;
                case 1://Resta
                    resultado = num1 - num2;
                    break;
                case 2://Multiplicacion
                    resultado = num1 * num2;
                    break;
                case 3://Division
                    resultado = num1 / num2;
                    break;
                case 4://Exponente
                    resultado = Math.Pow(num1, num2);
                    break;
                case 5://Raiz
                    resultado = Math.Pow(num1, 1 / num2);
                    break;
                case 6://Factorial
                    resultado = 1;
                    for (int i = 1; i <= num1; i++) {
                        resultado = resultado * i;
                    }
                    break;
            }
            lblRespuesta.Text = "Respuesta: " + Math.Round(resultado, 4).ToString();
        }
    }
}
