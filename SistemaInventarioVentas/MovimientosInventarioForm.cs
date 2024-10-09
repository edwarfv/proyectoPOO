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
    public partial class MovimientosInventarioForm : Form
    {
        private BaseDatos db = new BaseDatos();

        public MovimientosInventarioForm()
        {
            InitializeComponent();
            CargarProductos(); // Cargar la lista de productos en el ComboBox
            CargarMovimientosInventario(); // Cargar los movimientos de inventario
        }

        // Método para cargar los productos en el ComboBox
        private void CargarProductos()
        {
            try
            {
                DataTable dtProductos = db.ObtenerProductos();
                cmbProducto.DataSource = dtProductos;
                cmbProducto.DisplayMember = "Nombre"; // Mostrar el nombre del producto
                cmbProducto.ValueMember = "Id";       // El valor será el ID del producto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los movimientos de inventario desde la base de datos
        private void CargarMovimientosInventario()
        {
            try
            {
                dgvMovimientosInventario.DataSource = db.ObtenerMovimientosInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los movimientos de inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para agregar un movimiento de inventario
        private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que todos los campos estén llenos correctamente
                if (cmbProducto.SelectedItem == null || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una nueva instancia de MovimientoInventario con todos los parámetros requeridos
                var movimiento = new MovimientoInventario(
                    id: 0, // En el caso de agregar un nuevo movimiento, el Id generalmente es 0 o puede ser generado automáticamente por la base de datos
                    productoId: int.Parse(cmbProducto.SelectedValue.ToString()), // Obtener el Id del producto seleccionado
                    cantidad: int.Parse(txtCantidad.Text), // Obtener la cantidad del movimiento
                    tipoMovimiento: cmbTipoMovimiento.SelectedItem.ToString(), // Obtener el tipo de movimiento (Entrada o Salida)
                    fecha: dtpFecha.Value, // Obtener la fecha seleccionada en el DateTimePicker
                    motivo: txtMotivo.Text // Obtener el motivo del movimiento desde el TextBox
                );

                // Agregar el movimiento a la base de datos
                db.AgregarMovimientoInventario(movimiento);

                // Recargar los movimientos en la interfaz de usuario
                CargarMovimientosInventario();

                // Limpiar los campos después de agregar el movimiento
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en los campos correspondientes.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para actualizar un movimiento de inventario seleccionado
        private void btnActualizarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMovimientosInventario.SelectedRows.Count > 0)
                {
                    // Obtener el Id del movimiento seleccionado desde el DataGridView
                    int id = int.Parse(dgvMovimientosInventario.SelectedRows[0].Cells["Id"].Value.ToString());

                    // Crear una nueva instancia de MovimientoInventario con todos los parámetros
                    var movimiento = new MovimientoInventario(
                        id: id, // Usar el Id del movimiento seleccionado
                        productoId: int.Parse(cmbProducto.SelectedValue.ToString()), // Obtener el Id del producto seleccionado
                        cantidad: int.Parse(txtCantidad.Text), // Cantidad del movimiento
                        tipoMovimiento: cmbTipoMovimiento.SelectedItem.ToString(), // Tipo de movimiento (Entrada o Salida)
                        fecha: dtpFecha.Value, // Fecha seleccionada
                        motivo: txtMotivo.Text // Motivo del movimiento desde el TextBox
                    );

                    // Actualizar el movimiento en la base de datos
                    db.ActualizarMovimientoInventario(movimiento);

                    // Recargar los movimientos en la interfaz de usuario
                    CargarMovimientosInventario();

                    // Limpiar los campos después de actualizar el movimiento
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un movimiento para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Por favor, ingresa valores numéricos válidos en los campos correspondientes. Error: {ex.Message}", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar un movimiento de inventario seleccionado
        private void btnEliminarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMovimientosInventario.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvMovimientosInventario.SelectedRows[0].Cells["Id"].Value.ToString());

                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este movimiento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        db.EliminarMovimientoInventario(id); // Eliminar el movimiento de inventario
                        CargarMovimientosInventario();
                        LimpiarCampos(); // Limpiar campos después de eliminar
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un movimiento para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            cmbProducto.SelectedIndex = -1;
            cmbTipoMovimiento.SelectedIndex = -1;
            txtCantidad.Clear();
            dtpFecha.Value = DateTime.Now;
            txtMotivo.Clear();
        }

        private void MovimientosInventarioForm_Load(object sender, EventArgs e)
        {

        }
    }
}