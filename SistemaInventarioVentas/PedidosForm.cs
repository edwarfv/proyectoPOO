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
    public partial class PedidosForm : Form
    {
        private BaseDatos db = new BaseDatos();

        public PedidosForm()
        {
            InitializeComponent();
            CargarProveedores(); // Cargar la lista de proveedores en el ComboBox
            CargarPedidos(); // Cargar la lista de pedidos en el DataGridView
        }

        // Método para cargar los proveedores en el ComboBox
        private void CargarProveedores()
        {
            try
            {
                DataTable dtProveedores = db.ObtenerProveedores(); // Obtener proveedores desde la base de datos

                cmbProveedor.DataSource = dtProveedores; // Asignar el DataTable al ComboBox
                cmbProveedor.DisplayMember = "Nombre";  // Mostrar el nombre del proveedor en el ComboBox
                cmbProveedor.ValueMember = "Id";        // El valor será el ID del proveedor
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los pedidos desde la base de datos
        private void CargarPedidos()
        {
            try
            {
                dgvPedidos.DataSource = db.ObtenerPedidos(); // Mostrar los pedidos en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para agregar un pedido
        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (cmbProveedor.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, selecciona un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Crear una instancia del pedido pasando todos los argumentos requeridos
                    var pedido = new Pedido(
                        int.Parse(cmbProveedor.SelectedValue.ToString()), // Obtener el ID del proveedor seleccionado
                        dtpFecha.Value, // Obtener la fecha seleccionada del DateTimePicker
                        txtEstadoPedido.Text,  // Obtener el estado del pedido
                        decimal.Parse(txtTotal.Text) // Obtener el total del pedido
                    );

                    db.AgregarPedido(pedido); // Agregar el pedido a la base de datos
                    CargarPedidos(); // Recargar la lista de pedidos
                    LimpiarCampos(); // Limpiar campos después de agregar
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

            // Evento para actualizar un pedido seleccionado
            private void btnActualizarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPedidos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del pedido seleccionado
                    int id = int.Parse(dgvPedidos.SelectedRows[0].Cells["Id"].Value.ToString());

                    // Crear una instancia del pedido pasando todos los argumentos requeridos
                    var pedido = new Pedido(
                        int.Parse(cmbProveedor.SelectedValue.ToString()), // Obtener el ID del proveedor seleccionado
                        dtpFecha.Value, // Obtener la fecha seleccionada del DateTimePicker
                        txtEstadoPedido.Text,  // Obtener el estado del pedido
                        decimal.Parse(txtTotal.Text) // Obtener el total del pedido
                    )
                    {
                        Id = id // Asignar el ID al pedido
                    };

                    db.ActualizarPedido(pedido); // Actualizar el pedido en la base de datos
                    CargarPedidos(); // Recargar la lista de pedidos
                    LimpiarCampos(); // Limpiar campos después de actualizar
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un pedido para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar un pedido seleccionado
        private void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPedidos.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvPedidos.SelectedRows[0].Cells[0].Value.ToString());

                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este pedido?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        db.EliminarPedido(id); // Eliminar el pedido de la base de datos
                        CargarPedidos();
                        LimpiarCampos(); // Limpiar campos después de eliminar
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un pedido para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para búsqueda dinámica de pedidos
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarPedidos(); // Si el campo de búsqueda está vacío, cargar todos los pedidos
                }
                else
                {
                    dgvPedidos.DataSource = db.BuscarPedidos(txtBuscar.Text); // Filtrar los pedidos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para cargar datos seleccionados en los TextBox y el DateTimePicker
        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPedidos.Rows[e.RowIndex];

                cmbProveedor.SelectedValue = fila.Cells["ProveedorId"].Value;
                dtpFecha.Value = DateTime.Parse(fila.Cells["FechaPedido"].Value.ToString()); // Asignar la fecha seleccionada en el DateTimePicker
                txtEstadoPedido.Text = fila.Cells["EstadoPedido"].Value.ToString();
                txtTotal.Text = fila.Cells["Total"].Value.ToString();
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            cmbProveedor.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;  // Restablecer el DateTimePicker a la fecha actual
            txtEstadoPedido.Clear();
            txtTotal.Clear();
            txtBuscar.Clear();
        }

        private void PedidosForm_Load(object sender, EventArgs e)
        {

        }
    }
}