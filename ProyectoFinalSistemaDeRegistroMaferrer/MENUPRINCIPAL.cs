using System;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    public partial class MENUPRINCIPAL : Form
    {
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInicio ventanaInicio = new frmInicio();
            ventanaInicio.Show();
        }

        private void aPORTACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaportaciones ventanaAportaciones = new frmaportaciones();
            ventanaAportaciones.Show();
        }

        private void hABITANTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmhabitantes ventanaHabitantes = new frmhabitantes();
            ventanaHabitantes.Show();
        }

        private void vISITANTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmregistrovt ventanaVisitantes = new frmregistrovt();
            ventanaVisitantes.Show();
        }

        private void rEPORTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportes ventanaReportes = new frmReportes();
            ventanaReportes.Show();
        }

        private void iNCIDENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global::Incidentes.incidentes ventanaIncidentes = new global::Incidentes.incidentes();
            ventanaIncidentes.Show();
        }
    }
}