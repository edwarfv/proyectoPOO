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

            dgvMovimientosInventario.CellClick += new DataGridViewCellEventHandler(dgvMovimientosInventario_CellClick);
            CargarTiposMovimiento(); // Cargar la lista de tipos de movimiento primero
            CargarProductos();       // Cargar la lista de productos en el ComboBox
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
                cmbProducto.SelectedIndex = -1;  // Ningún producto seleccionado al cargar
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
                // Ajustar los encabezados de las columnas, si es necesario
                dgvMovimientosInventario.Columns["Id"].Visible = false;  // Ocultar la columna Id
                dgvMovimientosInventario.AutoResizeColumns();  // Ajustar el tamaño de las columnas automáticamente
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los movimientos de inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para agregar un movimiento de inventario
        /*private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos tengan valores
                if (cmbProducto.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                    string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int productoId = int.Parse(cmbProducto.SelectedValue.ToString());
                int cantidad = int.Parse(txtCantidad.Text);
                string tipoMovimiento = cmbTipoMovimiento.SelectedItem.ToString();
                DateTime fecha = dtpFecha.Value;
                string motivo = txtMotivo.Text;

                // Verificar si se trata de una salida y si hay suficiente inventario
                int cantidadActual = db.ObtenerCantidadProducto(productoId);
                if (tipoMovimiento == "Salida" && cantidad > cantidadActual)
                {
                    MessageBox.Show("No hay suficiente cantidad en inventario para realizar la salida.", "Error de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calcular la nueva cantidad de inventario
                int nuevaCantidad = tipoMovimiento == "Entrada"
                    ? cantidadActual + cantidad
                    : cantidadActual - cantidad;

                // Crear una nueva instancia de MovimientoInventario con todos los parámetros requeridos
                var movimiento = new MovimientoInventario
                (
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
        }*/
        private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos tengan valores válidos
                if (cmbProducto.SelectedValue == null || 
                    cmbTipoMovimiento.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtCantidad.Text) || 
                    string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor que cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int productoId = Convert.ToInt32(cmbProducto.SelectedValue);
                string tipoMovimiento = cmbTipoMovimiento.SelectedItem.ToString();
                DateTime fecha = dtpFecha.Value;
                string motivo = txtMotivo.Text;

                // Verificar si se trata de una salida y si hay suficiente inventario
                int cantidadActual = db.ObtenerCantidadProducto(productoId);
                if (tipoMovimiento == "Salida" && cantidad > cantidadActual)
                {
                    MessageBox.Show("No hay suficiente cantidad en inventario para realizar la salida.", "Error de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calcular la nueva cantidad de inventario
                int nuevaCantidad = tipoMovimiento == "Entrada"
                    ? cantidadActual + cantidad
                    : cantidadActual - cantidad;

                // Crear una nueva instancia de MovimientoInventario con todos los parámetros requeridos
                var movimiento = new MovimientoInventario(
                    id: 0, // El ID es generado automáticamente por la base de datos
                    productoId: productoId,
                    cantidad: cantidad,
                    tipoMovimiento: tipoMovimiento,
                    fecha: fecha,
                    motivo: motivo
                );

                // Agregar el movimiento a la base de datos
                db.AgregarMovimientoInventario(movimiento);

                // Actualizar la cantidad del producto en la base de datos
                db.ActualizarCantidadProducto(productoId, nuevaCantidad);

                // Recargar los movimientos en la interfaz de usuario
                CargarMovimientosInventario();

                // Limpiar los campos después de agregar el movimiento
                LimpiarCampos();

                MessageBox.Show("Movimiento agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    // Obtener el Id del movimiento seleccionado
                    int id = Convert.ToInt32(dgvMovimientosInventario.SelectedRows[0].Cells["Id"].Value);

                    if (cmbProducto.SelectedItem == null ||
                        string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                        string.IsNullOrWhiteSpace(txtMotivo.Text))
                    {
                        MessageBox.Show("Por favor, completa todos los campos antes de actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Obtener los datos actuales del movimiento
                    int productoId = Convert.ToInt32(cmbProducto.SelectedValue);
                    int nuevaCantidad = Convert.ToInt32(txtCantidad.Text);
                    string tipoMovimiento = cmbTipoMovimiento.SelectedItem.ToString();
                    DateTime fecha = dtpFecha.Value;
                    string motivo = txtMotivo.Text;

                    // Obtener la cantidad actual del producto desde la base de datos
                    int cantidadActualProducto = db.ObtenerCantidadProducto(productoId);

                    // Obtener la cantidad anterior del movimiento seleccionado
                    int cantidadAnteriorMovimiento = Convert.ToInt32(dgvMovimientosInventario.SelectedRows[0].Cells["Cantidad"].Value);

                    // Calcular la nueva cantidad en el inventario
                    int cantidadNuevaEnInventario = tipoMovimiento == "Entrada"
                        ? cantidadActualProducto - cantidadAnteriorMovimiento + nuevaCantidad
                        : cantidadActualProducto + cantidadAnteriorMovimiento - nuevaCantidad;

                    // Actualizar la cantidad del producto en la base de datos
                    db.ActualizarCantidadProducto(productoId, cantidadNuevaEnInventario);

                    // Crear instancia de MovimientoInventario
                    var movimiento = new MovimientoInventario(
                        id: id,
                        productoId: productoId,
                        cantidad: nuevaCantidad,
                        tipoMovimiento: tipoMovimiento,
                        fecha: fecha,
                        motivo: motivo
                    );

                    // Actualizar el movimiento en la base de datos
                    db.ActualizarMovimientoInventario(movimiento);

                    // Recargar los movimientos y limpiar campos
                    CargarMovimientosInventario();
                    LimpiarCampos();

                    MessageBox.Show("Movimiento actualizado correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un movimiento para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Por favor, ingresa valores numéricos válidos. Error: {ex.Message}", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    int id = Convert.ToInt32(dgvMovimientosInventario.SelectedRows[0].Cells["Id"].Value);
                    int productoId = Convert.ToInt32(dgvMovimientosInventario.SelectedRows[0].Cells["ProductoId"].Value);
                    int cantidadMovimiento = Convert.ToInt32(dgvMovimientosInventario.SelectedRows[0].Cells["Cantidad"].Value);
                    string tipoMovimiento = dgvMovimientosInventario.SelectedRows[0].Cells["TipoMovimiento"].Value.ToString();

                    // Obtener la cantidad actual del producto
                    int cantidadActualProducto = db.ObtenerCantidadProducto(productoId);

                    // Calcular la nueva cantidad de inventario
                    int cantidadNuevaEnInventario = tipoMovimiento == "Entrada"
                        ? cantidadActualProducto - cantidadMovimiento
                        : cantidadActualProducto + cantidadMovimiento;

                    // Actualizar la cantidad del producto en la base de datos
                    db.ActualizarCantidadProducto(productoId, cantidadNuevaEnInventario);

                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este movimiento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        // Eliminar el movimiento de inventario
                        db.EliminarMovimientoInventario(id);

                        // Recargar los movimientos y limpiar campos
                        CargarMovimientosInventario();
                        LimpiarCampos();

                        MessageBox.Show("Movimiento eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CargarTiposMovimiento(); // Llamar al método para cargar las opciones del ComboBox
        }

        private void cmbTipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay un valor seleccionado antes de continuar
            if (cmbTipoMovimiento.SelectedItem == null)
            {
                return; // Si no hay una opción seleccionada, salir del método
            }

            // Obtener la opción seleccionada y actuar en consecuencia
            string tipoMovimiento = cmbTipoMovimiento.SelectedItem.ToString();

            
            if (tipoMovimiento == "Entrada")
            {
                // Lógica específica para "Entrada"
                // Por ejemplo, habilitar ciertos campos o mostrar información
            }
            else if (tipoMovimiento == "Salida")
            {
                // Lógica específica para "Salida"
                // Por ejemplo, habilitar otros campos o mostrar otra información
            }
        }

        private void CargarTiposMovimiento()
        {
            try
            {
                // Limpiar cualquier elemento existente
                cmbTipoMovimiento.Items.Clear();

                // Añadir las opciones "Entrada" y "Salida"
                cmbTipoMovimiento.Items.Add("Entrada");
                cmbTipoMovimiento.Items.Add("Salida");

                // Establecer "Entrada" como la opción predeterminada
                cmbTipoMovimiento.SelectedIndex = 0;

                // Asignar el evento SelectedIndexChanged después de cargar las opciones
                //cmbTipoMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMovimiento_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void dgvMovimientosInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMovimientosInventario.Rows[e.RowIndex];

                // Asignar los valores de la fila seleccionada a los controles correspondientes
                cmbProducto.SelectedValue = row.Cells["ProductoId"].Value;
                txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
                cmbTipoMovimiento.SelectedItem = row.Cells["TipoMovimiento"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(row.Cells["Fecha"].Value);
                txtMotivo.Text = row.Cells["Motivo"].Value.ToString();
            }
        }*/
        private void dgvMovimientosInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMovimientosInventario.Rows[e.RowIndex];

                // Asignar los valores de la fila seleccionada a los controles correspondientes, verificando si son nulos
                cmbProducto.SelectedValue = row.Cells["ProductoId"].Value != DBNull.Value ? row.Cells["ProductoId"].Value : -1;
                txtCantidad.Text = row.Cells["Cantidad"].Value != DBNull.Value ? row.Cells["Cantidad"].Value.ToString() : string.Empty;
                cmbTipoMovimiento.SelectedItem = row.Cells["TipoMovimiento"].Value != DBNull.Value ? row.Cells["TipoMovimiento"].Value.ToString() : string.Empty;

                // Verificar si la fecha no es DBNull antes de asignarla
                if (row.Cells["Fecha"].Value != DBNull.Value)
                {
                    dtpFecha.Value = Convert.ToDateTime(row.Cells["Fecha"].Value);
                }
                else
                {
                    dtpFecha.Value = DateTime.Now; // Establece una fecha predeterminada si el valor es nulo
                }

                txtMotivo.Text = row.Cells["Motivo"].Value != DBNull.Value ? row.Cells["Motivo"].Value.ToString() : string.Empty;
            }
        }

        private void txtBuscarMovimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Si el campo de búsqueda está vacío, cargar todos los movimientos
                if (string.IsNullOrWhiteSpace(txtBuscarMovimiento.Text))
                {
                    CargarMovimientosInventario();
                }
                else
                {
                    // Filtrar movimientos por el valor ingresado en el TextBox de búsqueda
                    dgvMovimientosInventario.DataSource = db.BuscarMovimientosInventario(txtBuscarMovimiento.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar movimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}