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
    public partial class PagosForm : Form
    {
        private BaseDatos db = new BaseDatos();

        public PagosForm()
        {
            InitializeComponent();
            CargarVentas(); // Cargar la lista de ventas en el ComboBox
            CargarMetodosPago(); // Cargar la lista de métodos de pago en el ComboBox
            CargarPagos(); // Cargar la lista de pagos en el DataGridView
        }

        // Método para cargar las ventas en el ComboBox
        private void CargarVentas()
        {
            try
            {
                DataTable dtVentas = db.ObtenerVentas(); // Obtener ventas desde la base de datos
                cmbVenta.DataSource = dtVentas;
                cmbVenta.DisplayMember = "Id"; // Mostrar el ID de la venta
                cmbVenta.ValueMember = "Id";   // El valor será el ID de la venta
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los métodos de pago en el ComboBox
        private void CargarMetodosPago()
        {
            try
            {
                DataTable dt = db.ObtenerMetodosPagoParaPagos(); // Usar el método específico para pagos
                cmbMetodosPago.DataSource = dt;
                cmbMetodosPago.DisplayMember = "Metodo";  // Nombre del método de pago
                cmbMetodosPago.ValueMember = "Id";        // ID del método de pago
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los métodos de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los pagos desde la base de datos
        private void CargarPagos()
        {
            try
            {
                dgvPagos.DataSource = db.ObtenerPagos(); // Mostrar los pagos en el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para agregar un pago
        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbVenta.SelectedItem == null || cmbMetodosPago.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona una venta y un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var pago = new Pago(
                    int.Parse(cmbVenta.SelectedValue.ToString()),      // Obtener el ID de la venta seleccionada
                    int.Parse(cmbMetodosPago.SelectedValue.ToString()), // Obtener el ID del método de pago seleccionado
                    dtpFechaPago.Value,                                // Obtener la fecha seleccionada del DateTimePicker
                    decimal.Parse(txtMonto.Text)                       // Obtener el monto del pago
                );

                db.AgregarPago(pago); // Agregar el pago a la base de datos
                CargarPagos(); // Recargar la lista de pagos
                LimpiarCampos(); // Limpiar campos después de agregar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para actualizar un pago seleccionado
        private void btnActualizarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPagos.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvPagos.SelectedRows[0].Cells["Id"].Value.ToString());

                    var pago = new Pago(
                        int.Parse(cmbVenta.SelectedValue.ToString()),      // Obtener el ID de la venta seleccionada
                        int.Parse(cmbMetodosPago.SelectedValue.ToString()), // Obtener el ID del método de pago seleccionado
                        dtpFechaPago.Value,                                // Obtener la fecha seleccionada
                        decimal.Parse(txtMonto.Text)                       // Obtener el monto del pago
                    )
                    {
                        Id = id // Asignar el ID del pago
                    };

                    db.ActualizarPago(pago); // Actualizar el pago en la base de datos
                    CargarPagos();
                    LimpiarCampos(); // Limpiar campos después de actualizar
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un pago para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar un pago seleccionado
        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPagos.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvPagos.SelectedRows[0].Cells["Id"].Value.ToString());

                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este pago?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        db.EliminarPago(id); // Eliminar el pago de la base de datos
                        CargarPagos();
                        LimpiarCampos(); // Limpiar campos después de eliminar
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un pago para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            cmbVenta.SelectedIndex = -1;
            cmbMetodosPago.SelectedIndex = -1;
            dtpFechaPago.Value = DateTime.Now;
            txtMonto.Clear();
        }
    }
}