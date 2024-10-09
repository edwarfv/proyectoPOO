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
    public partial class ClientesForm : Form
    {
        // Instancia de la clase BaseDatos para gestionar los clientes
        private BaseDatos db = new BaseDatos();

        public ClientesForm()
        {
            InitializeComponent();
            CargarClientes(); // Cargar la lista de clientes al iniciar el formulario
        }

        // Método para cargar los clientes desde la base de datos
        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = db.ObtenerClientes(); // Mostrar los clientes en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para el botón de agregar cliente
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear una instancia de la clase Cliente con los datos del formulario
                var cliente = new Cliente(txtNombre.Text, txtEmail.Text, txtTelefono.Text, txtDireccion.Text);

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(cliente.Nombre) || string.IsNullOrWhiteSpace(cliente.Email) ||
                    string.IsNullOrWhiteSpace(cliente.Telefono) || string.IsNullOrWhiteSpace(cliente.Direccion))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método para agregar el cliente en la base de datos
                db.AgregarCliente(cliente);

                // Actualizar la lista de clientes en el DataGridView
                CargarClientes();
                LimpiarCampos(); // Limpiar los campos después de agregar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para actualizar un cliente seleccionado
        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Asegúrate de que todos los TextBoxes tengan información
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verifica si hay alguna fila seleccionada
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    // Obtener el ID del cliente seleccionado
                    int id = int.Parse(dgvClientes.SelectedRows[0].Cells["Id"].Value.ToString());

                    // Crear una instancia del cliente pasando los argumentos requeridos
                    var cliente = new Cliente(
                        txtNombre.Text,
                        txtTelefono.Text,
                        txtEmail.Text,
                        txtDireccion.Text
                    )
                    {
                        Id = id // Asigna el ID al cliente
                    };

                    db.ActualizarCliente(cliente); // Llama al método para actualizar cliente en la base de datos
                    CargarClientes(); // Recarga la lista de clientes
                    LimpiarCampos(); // Limpia los campos después de actualizar
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un cliente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar un cliente seleccionado
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count > 0) // Verificar que haya una fila seleccionada
                {
                    int id = int.Parse(dgvClientes.SelectedRows[0].Cells[0].Value.ToString()); // Obtener el ID del cliente seleccionado

                    // Confirmación antes de eliminar
                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        // Eliminar el cliente de la base de datos
                        db.EliminarCliente(id);

                        // Recargar la lista de clientes
                        CargarClientes();
                        LimpiarCampos(); // Limpiar los campos después de eliminar
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para búsqueda dinámica de clientes
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarClientes(); // Si el campo de búsqueda está vacío, cargar todos los clientes
                }
                else
                {
                    // Buscar los clientes cuyo nombre coincida con el texto ingresado
                    dgvClientes.DataSource = db.BuscarClientes(txtBuscar.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para seleccionar un cliente desde el DataGridView
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Verifica si la fila seleccionada es válida
                {
                    DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                    // Llenar los TextBox con la información seleccionada
                    txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                    txtEmail.Text = fila.Cells["Email"].Value.ToString();
                    txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                    txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();
        }
    }
}