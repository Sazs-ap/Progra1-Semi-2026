using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Método auxiliar para abrir formularios dentro del contenedor MDI sin duplicarlos
        private void AbrirFormulario<TForm>() where TForm : Form, new()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is TForm)
                {
                    frm.BringToFront();
                    frm.WindowState = FormWindowState.Normal;
                    return;
                }
            }

            TForm nuevoFormulario = new TForm();
            nuevoFormulario.MdiParent = this;
            nuevoFormulario.Show();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form1>();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmMateria>();
        }

        private void periodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmPeriodos>();
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmNotas>();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}