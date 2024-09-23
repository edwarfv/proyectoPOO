using System;
using System.Windows.Forms;

namespace SistemaInventarioVentas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configura la aplicación para usar los estilos visuales de Windows y hace compatible el renderizado de texto.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia el programa mostrando el formulario de login.
            LoginForm loginForm = new LoginForm();

            // Si el login fue exitoso, muestra el formulario principal.
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Ejecuta el formulario principal (Form1).
                Application.Run(new Form1());
            }

            // Libera los recursos del formulario de login después de cerrarlo.
            loginForm.Dispose();
        }
    }
}
