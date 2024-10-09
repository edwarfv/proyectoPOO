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
    public partial class VentasForm : Form
    {
        private BaseDatos db = new BaseDatos();

        public VentasForm()
        {
            InitializeComponent();
            CargarClientes(); // Cargar la lista de clientes en el ComboBox
            CargarVentas(); // Cargar la lista de ventas en el DataGridView
        }

        // Método para cargar los clientes en el ComboBox
        private void CargarClientes()
        {
            try
            {
                DataTable dtClientes = db.ObtenerClientes(); // Obtener clientes desde la base de datos

                cmbCliente.DataSource = dtClientes; // Asignar el DataTable al ComboBox
                cmbCliente.DisplayMember = "Nombre"; // Mostrar el nombre del cliente en el ComboBox
                cmbCliente.ValueMember = "Id"; // El valor será el ID del cliente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar las ventas desde la base de datos
        private void CargarVentas()
        {
            try
            {
                dgvVentas.DataSource = db.ObtenerVentas(); // Mostrar las ventas en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para agregar una venta
        private void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCliente.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una instancia de la venta pasando todos los argumentos requeridos
                var venta = new Venta(
                    int.Parse(cmbCliente.SelectedValue.ToString()), // Obtener el ID del cliente seleccionado
                    dtpFecha.Value, // Obtener la fecha seleccionada del DateTimePicker
                    decimal.Parse(txtTotal.Text) // Obtener el total de la venta
                );

                db.AgregarVenta(venta); // Agregar la venta a la base de datos
                CargarVentas(); // Recargar la lista de ventas
                LimpiarCampos(); // Limpiar campos después de agregar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para actualizar una venta seleccionada
        private void btnActualizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvVentas.SelectedRows[0].Cells["Id"].Value.ToString());

                    // Crear una instancia de la venta pasando todos los argumentos requeridos
                    var venta = new Venta(
                        int.Parse(cmbCliente.SelectedValue.ToString()), // Obtener el ID del cliente seleccionado
                        dtpFecha.Value, // Obtener la fecha seleccionada del DateTimePicker
                        decimal.Parse(txtTotal.Text) // Obtener el total de la venta
                    )
                    {
                        Id = id // Asignar el ID a la venta
                    };

                    db.ActualizarVenta(venta); // Actualizar la venta en la base de datos
                    CargarVentas(); // Recargar la lista de ventas
                    LimpiarCampos(); // Limpiar campos después de actualizar
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una venta para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar una venta seleccionada
        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVentas.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvVentas.SelectedRows[0].Cells["Id"].Value.ToString());

                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar esta venta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        db.EliminarVenta(id); // Eliminar la venta de la base de datos
                        CargarVentas(); // Recargar la lista de ventas
                        LimpiarCampos(); // Limpiar campos después de eliminar
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una venta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1; // Restablecer el ComboBox del cliente
            dtpFecha.Value = DateTime.Now; // Restablecer el DateTimePicker a la fecha actual
            txtTotal.Clear(); // Limpiar el campo del total
        }


    }
}