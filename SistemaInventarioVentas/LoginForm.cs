using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventarioVentas
{
    public partial class LoginForm : Form
    {
        // Instancia de la clase BaseDatos para gestionar la conexión con la base de datos.
        private BaseDatos db = new BaseDatos();
        // Constructor del formulario LoginForm.
        public LoginForm()
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
        }
       
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        // Evento que se ejecuta al hacer clic en el botón de login.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text; // Captura el nombre de usuario ingresado.
            string password = txtPassword.Text; // Captura la contraseña ingresada.

            // Llama al método de validación de usuario de la clase BaseDatos.
            if (db.ValidarUsuario(username, password)) // Si la autenticación es exitosa
            {
                this.Hide(); // Ocultamos el formulario de login en lugar de cerrarlo
                this.DialogResult = DialogResult.OK; // Marcamos el resultado como OK para indicar éxito
            }
            else
            {
                // Muestra un mensaje de error si las credenciales son incorrectas.
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
