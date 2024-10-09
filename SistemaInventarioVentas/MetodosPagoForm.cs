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
    public partial class MetodosPagoForm : Form
    {
        private BaseDatos db = new BaseDatos(); // Instancia de la clase BaseDatos

        public MetodosPagoForm()
        {
            InitializeComponent();
            CargarMetodosPago();
        }

        // Método para cargar los métodos de pago en el DataGridView
        private void CargarMetodosPago()
        {
            try
            {
                // Llamar al método correcto de la clase BaseDatos para obtener todos los métodos de pago
                DataTable dt = db.ObtenerMetodosPagoParaConfiguracion(); // Usar el método correcto
                dgvMetodosPago.DataSource = dt; // Asignar el DataTable al DataGridView
                dgvMetodosPago.Columns["Id"].Visible = false; // Si no quieres mostrar el ID
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los métodos de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para manejar la selección de filas en el DataGridView
        private void dgvMetodosPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMetodosPago.Rows[e.RowIndex];
                txtMetodoPago.Text = row.Cells["Metodo"].Value.ToString(); // Llenar el TextBox con el método seleccionado
            }
        }

        
        // Método para agregar un nuevo método de pago
        private void btnAgregarMetodoPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtMetodoPago.Text))
                {
                    // Crear una nueva instancia de MetodoPago
                    MetodoPago nuevoMetodo = new MetodoPago(txtMetodoPago.Text);

                    // Llamar al método de la clase BaseDatos para agregar el método
                    db.AgregarMetodoPago(nuevoMetodo);

                    // Recargar los métodos de pago después de agregar
                    CargarMetodosPago();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, introduce un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el método de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para actualizar un método de pago existente
        private void btnActualizarMetodoPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMetodosPago.SelectedRows.Count > 0 && !string.IsNullOrWhiteSpace(txtMetodoPago.Text))
                {
                    int id = int.Parse(dgvMetodosPago.SelectedRows[0].Cells["Id"].Value.ToString());
                    db.ActualizarMetodoPago(id, txtMetodoPago.Text); // Suponiendo que tienes este método en BaseDatos
                    CargarMetodosPago(); // Recargar después de actualizar
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un método de pago para actualizar y completa el campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el método de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para eliminar un método de pago
        private void btnEliminarMetodoPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMetodosPago.SelectedRows.Count > 0)
                {
                    int id = int.Parse(dgvMetodosPago.SelectedRows[0].Cells["Id"].Value.ToString());
                    db.EliminarMetodoPago(id); // Suponiendo que tienes este método en la clase BaseDatos
                    CargarMetodosPago(); // Recargar después de eliminar
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un método de pago para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el método de pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos
        private void LimpiarCampos()
        {
            txtMetodoPago.Clear();
        }
    }
}