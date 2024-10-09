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
    public partial class UsuariosForm : Form
    {
        private BaseDatos db = new BaseDatos();

        public UsuariosForm()
        {
            InitializeComponent();
            CargarUsuarios(); // Cargar la lista de usuarios
        }

        // Método para cargar los usuarios desde la base de datos
        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = db.ObtenerUsuarios(); // Mostrar los usuarios en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para agregar un usuario
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var usuario = new Usuario(txtUsername.Text, txtPassword.Text);

                db.AgregarUsuario(usuario); // Agregar el usuario a la base de datos
                CargarUsuarios(); // Recargar la lista de usuarios
                LimpiarCampos(); // Limpiar campos después de agregar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para actualizar un usuario seleccionado
        private void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvUsuarios.SelectedRows[0].Cells["Id"].Value.ToString());

                    var usuario = new Usuario(txtUsername.Text, txtPassword.Text)
                    {
                        Id = id
                    };

                    db.ActualizarUsuario(usuario); // Actualizar el usuario en la base de datos
                    CargarUsuarios(); // Recargar la lista de usuarios
                    LimpiarCampos(); // Limpiar campos después de actualizar
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un usuario para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar un usuario seleccionado
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvUsuarios.SelectedRows[0].Cells["Id"].Value.ToString());

                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        db.EliminarUsuario(id); // Eliminar el usuario de la base de datos
                        CargarUsuarios(); // Recargar la lista
                        LimpiarCampos(); // Limpiar campos después de eliminar
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}