
using System;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class MENUPRINCIPAL : Form
    {
        private bool formularioAbierto = false;

        public MENUPRINCIPAL()
        {
            InitializeComponent();
        }

        private void MENUPRINCIPAL_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void AbrirFormulario(Form formulario)
        {
            // Evitar abrir varios formularios al mismo tiempo
            if (formularioAbierto)
            {
                formulario.Dispose();
                return;
            }

            formularioAbierto = true;
            this.Hide();

            formulario.FormClosed += (s, args) =>
            {
                formularioAbierto = false;
                this.Show();
                this.Activate();
            };

            formulario.Show();
        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInicio());
        }

        private void aPORTACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmaportaciones());
        }

        private void hABITANTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmhabitantes());
        }

        private void vISITANTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmregistrovt());
        }

        private void rEPORTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }

        private void iNCIDENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new global::Incidentes.incidentes());
        }

        private void menuStrip1_ItemClicked(
            object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SALIR DEL SISTEMA 
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
