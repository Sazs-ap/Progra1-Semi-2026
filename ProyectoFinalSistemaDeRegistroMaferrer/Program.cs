using System;
using System.Windows.Forms;

namespace ProyectoFinalSistemaDeRegistroMaferrer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación abriendo primero tu formulario de inicio de sesión
            Application.Run(new frmIniciarsesion());
        }
    }
}