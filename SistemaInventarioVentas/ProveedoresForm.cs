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
    public partial class ProveedoresForm : Form
    {
        private BaseDatos db = new BaseDatos();

        public ProveedoresForm()
        {
            InitializeComponent();
            CargarProveedores(); // Cargar la lista de proveedores al iniciar el formulario

            txtBuscar.TextChanged += txtBuscar_TextChanged;  // Evento de búsqueda automática
            // Asignar el evento CellClick al DataGridView
            dgvProveedores.CellClick += dgvProveedores_CellClick;
        }

        // Método para cargar los proveedores desde la base de datos
        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = db.ObtenerProveedores();  // Llenar el DataGridView con la lista de proveedores desde la base de datos

                // Ajustar automáticamente el ancho de las columnas al contenido
                dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ajustar automáticamente la altura de las filas al contenido
                dgvProveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Alinear el encabezado para que tenga una buena presentación
                dgvProveedores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para agregar un proveedor
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                var proveedor = new Proveedor(txtNombre.Text, txtContacto.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text);

                if (string.IsNullOrWhiteSpace(proveedor.Nombre) || string.IsNullOrWhiteSpace(proveedor.Contacto) ||
                    string.IsNullOrWhiteSpace(proveedor.Telefono) || string.IsNullOrWhiteSpace(proveedor.Email) ||
                    string.IsNullOrWhiteSpace(proveedor.Direccion))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.AgregarProveedor(proveedor);
                CargarProveedores();
                LimpiarCampos(); // Limpiar campos después de agregar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para actualizar un proveedor seleccionado
        private void btnActualizarProveedor_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    // Asegúrate de que todos los TextBoxes tengan información
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtContacto.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                        string.IsNullOrWhiteSpace(txtEmail.Text) ||
                        string.IsNullOrWhiteSpace(txtDireccion.Text))
                    {
                        MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verifica si hay alguna fila seleccionada
                    if (dgvProveedores.SelectedRows.Count > 0)
                    {
                        // Obtener el ID del proveedor seleccionado
                        int id = int.Parse(dgvProveedores.SelectedRows[0].Cells["Id"].Value.ToString());

                        // Crear una instancia del proveedor pasando todos los argumentos requeridos
                        var proveedor = new Proveedor(
                            txtNombre.Text,
                            txtContacto.Text,
                            txtTelefono.Text,
                            txtEmail.Text,
                            txtDireccion.Text
                        )
                        {
                            Id = id // Asigna el ID al proveedor
                        };

                        db.ActualizarProveedor(proveedor); // Actualizar el proveedor en la base de datos
                        CargarProveedores(); // Recargar la lista de proveedores
                        LimpiarCampos(); // Limpiar campos después de actualizar
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecciona un proveedor para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

            // Evento para eliminar un proveedor seleccionado
            private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedores.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvProveedores.SelectedRows[0].Cells[0].Value.ToString());

                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        db.EliminarProveedor(id);
                        CargarProveedores();
                        LimpiarCampos(); // Limpiar campos después de eliminar
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un proveedor para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para búsqueda dinámica de proveedores
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarProveedores(); // Si el campo de búsqueda está vacío, cargar todos los proveedores
                }
                else
                {
                    // Buscar proveedores en la base de datos y actualizar el DataGridView
                    dgvProveedores.DataSource = db.BuscarProveedores(txtBuscar.Text);

                    // Validación adicional para asegurar que haya resultados antes de aplicar el formato
                    if (dgvProveedores.DataSource != null && dgvProveedores.Rows.Count > 0)
                    {
                        // Ajustar automáticamente el ancho de las columnas al contenido
                        dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Ajustar automáticamente la altura de las filas al contenido
                        dgvProveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        // Alinear el encabezado para que tenga una buena presentación
                        dgvProveedores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Evento para cargar datos seleccionados en los TextBox
        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar si el índice de fila es válido
            {
                DataGridViewRow fila = dgvProveedores.Rows[e.RowIndex];

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtContacto.Text = fila.Cells["Contacto"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtBuscar.Clear();
        }
    }
}
