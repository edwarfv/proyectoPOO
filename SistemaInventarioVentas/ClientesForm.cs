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
            // Evento de búsqueda automática
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // Evento para manejar la selección de una fila en el DataGridView
            dgvClientes.CellClick += dgvClientes_CellClick;
        }

        // Método para cargar los clientes desde la base de datos
        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = db.ObtenerClientes();  // Cargar los clientes desde la base de datos

                // Ajustar automáticamente el ancho de las columnas al contenido
                dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ajustar automáticamente la altura de las filas al contenido
                dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Alinear el encabezado para que tenga una buena presentación
                dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para el botón de agregar cliente
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            /*try
            {
                // Crear una instancia de la clase Cliente con los datos del formulario
                var cliente = new Cliente(txtNombre.Text, txtEmail.Text, txtTelefono.Text, txtDireccion.Text);

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(cliente.Nombre) || 
                    string.IsNullOrWhiteSpace(cliente.Email) ||
                    string.IsNullOrWhiteSpace(cliente.Telefono) || 
                    string.IsNullOrWhiteSpace(cliente.Direccion))
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
        }*/
            try
            {
                // Verificar que todos los campos tengan valores
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar longitud del número de teléfono
                if (txtTelefono.Text.Length > 15) // Puedes ajustar la longitud según tu necesidad
                {
                    MessageBox.Show("El número de teléfono no debe exceder los 15 caracteres.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una nueva instancia de Cliente con los valores ingresados
                Cliente cliente = new Cliente(
                    nombre: txtNombre.Text,
                    telefono: txtTelefono.Text,
                    email: txtEmail.Text,
                    direccion: txtDireccion.Text
                );

                // Agregar cliente a la base de datos
                db.AgregarCliente(cliente);

                // Recargar la lista de clientes en el DataGridView
                CargarClientes();

                // Limpiar los campos después de agregar el cliente
                LimpiarCampos();

                // Mostrar mensaje de éxito
                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Verificar que haya una fila seleccionada en el DataGridView
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    // Validar que todos los campos estén completos
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtEmail.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                        string.IsNullOrWhiteSpace(txtDireccion.Text))
                    {
                        MessageBox.Show("Por favor, completa todos los campos antes de actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Salir si los campos no están completos
                    }

                    // Obtener el ID del cliente seleccionado desde el DataGridView
                    int id = int.Parse(dgvClientes.SelectedRows[0].Cells["Id"].Value.ToString());

                    // Crear una nueva instancia de Cliente con los valores ingresados en los campos
                    Cliente cliente = new Cliente(
                        nombre: txtNombre.Text,
                        telefono: txtTelefono.Text,
                        email: txtEmail.Text,
                        direccion: txtDireccion.Text
                    )
                    {
                        Id = id // Asignar el Id del cliente seleccionado
                    };

                    // Confirmación antes de proceder con la actualización
                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas actualizar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacion == DialogResult.Yes)
                    {
                        // Actualizar el cliente en la base de datos
                        db.ActualizarCliente(cliente);

                        // Recargar la lista de clientes en el DataGridView
                        CargarClientes();

                        // Limpiar los campos después de actualizar
                        LimpiarCampos();

                        // Mostrar mensaje de éxito
                        MessageBox.Show("Cliente actualizado correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Mensaje en caso de que no haya fila seleccionada
                    MessageBox.Show("Por favor, selecciona un cliente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                // Manejar excepciones de formato inválido (por ejemplo, si se ingresa un valor no numérico en un campo numérico)
                MessageBox.Show($"Por favor, ingresa valores válidos en los campos correspondientes. Error: {ex.Message}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción
                MessageBox.Show($"Error al actualizar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    CargarClientes();  // Si el campo de búsqueda está vacío, mostrar todos los clientes
                }
                else
                {
                    dgvClientes.DataSource = db.BuscarClientes(txtBuscar.Text);  // Filtrar clientes por nombre
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