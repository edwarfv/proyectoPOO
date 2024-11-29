using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using MySql.Data.MySqlClient;


namespace SistemaInventarioVentas
{
    public partial class ProductosForm : Form
    {
        private BaseDatos db = new BaseDatos();  // Instancia para conectar con la base de datos

        public ProductosForm()
        {
            InitializeComponent();
            CargarProductos();  // Cargar los productos al iniciar el formulario
            CargarCategorias();  // Cargar las categorías al iniciar el formulario
        }

        // Método para cargar los productos en el DataGridView
        private void CargarProductos()
        {
            try
            {
                dgvProductos.AutoGenerateColumns = true;  // Dejar que el DataGridView genere las columnas automáticamente
                dgvProductos.DataSource = db.ObtenerProductos();  // Cargar productos desde la base de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar las categorías en el ComboBox
        private void CargarCategorias()
        {
            try
            {
                DataTable dtCategorias = db.ObtenerCategorias();  // Cargar categorías desde la base de datos
                //cmbCategorias.DataSource = db.ObtenerCategorias();  // Cargar categorías desde la base de datos
                cmbCategorias.DataSource = dtCategorias;
                cmbCategorias.DisplayMember = "Nombre"; // Nombre de la categoría a mostrar
                cmbCategorias.ValueMember = "Id";  // ID de la categoría a guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtBuscar.Clear();
            cmbCategorias.SelectedIndex = -1;  // Restablecer el ComboBox
        }

        // Evento para agregar un nuevo producto
        /*private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || cmbCategorias.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var producto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Cantidad = int.Parse(txtCantidad.Text),
                    CategoriaId = (int)cmbCategorias.SelectedValue  // Obtener el ID de la categoría seleccionada
                };

                db.AgregarProducto(producto);  // Agregar producto a la base de datos
                CargarProductos();  // Refrescar el DataGridView
                LimpiarCampos();  // Limpiar los campos

                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                    cmbCategorias.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la categoría seleccionada no sea null
                if (cmbCategorias.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, selecciona una categoría válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Obtener el valor de la categoría seleccionada
                int categoriaId = (int)cmbCategorias.SelectedValue;

                // Crear la instancia del producto
                var producto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Cantidad = int.Parse(txtCantidad.Text),
                    //CategoriaId = (int)cmbCategorias.SelectedValue // Obtener el ID de la categoría seleccionada
                    CategoriaId = categoriaId// Asignar el ID de la categoría al producto
                };

                // Agregar el producto a la base de datos
                db.AgregarProducto(producto);

                // Refrescar el DataGridView
                CargarProductos();

                // Limpiar los campos
                LimpiarCampos();

                MessageBox.Show("Producto agregado correctamente.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos en los campos correspondientes.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya seleccionado un producto en el DataGridView
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    // Validar que todos los campos estén completos
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                        string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                        cmbCategorias.SelectedIndex == -1)
                    {
                        MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validar que la categoría seleccionada no sea null
                    if (cmbCategorias.SelectedValue == null)
                    {
                        MessageBox.Show("Por favor, selecciona una categoría válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validar que los valores ingresados sean numéricos donde corresponda
                    if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || !int.TryParse(txtCantidad.Text, out int cantidad))
                    {
                        MessageBox.Show("Por favor, ingresa valores numéricos válidos para el precio y la cantidad.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Crear una nueva instancia del producto con la información proporcionada
                    var producto = new Producto
                    {
                        Id = int.Parse(dgvProductos.SelectedRows[0].Cells[0].Value.ToString()),  // Obtener el ID del producto seleccionado
                        Nombre = txtNombre.Text,
                        Precio = precio,  // Utilizar el valor parseado de precio
                        Cantidad = cantidad,  // Utilizar el valor parseado de cantidad
                        CategoriaId = (int)cmbCategorias.SelectedValue  // Obtener el ID de la categoría seleccionada
                    };

                    // Actualizar el producto en la base de datos
                    db.ActualizarProducto(producto);

                    // Refrescar los productos en el DataGridView
                    CargarProductos();

                    // Limpiar los campos después de actualizar el producto
                    LimpiarCampos();

                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un producto para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para eliminar un producto
       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    // Obtener el ID del producto seleccionado
                    int id = int.Parse(dgvProductos.SelectedRows[0].Cells[0].Value.ToString());

                    // Mostrar una confirmación antes de eliminar el producto
                    DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                                "Confirmación",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Warning);
                    if (confirmacion == DialogResult.Yes)
                    {
                        // Eliminar el producto de la base de datos
                        db.EliminarProducto(id);

                        // Refrescar la lista de productos en el DataGridView
                        CargarProductos();

                        // Limpiar los campos de entrada después de la eliminación
                        LimpiarCampos();

                        // Mostrar mensaje de éxito
                        MessageBox.Show("Producto eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Búsqueda dinámica
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    CargarProductos();  // Si el campo de búsqueda está vacío, mostrar todos los productos
                }
                else
                {
                    dgvProductos.DataSource = db.BuscarProductos(txtBuscar.Text);  // Filtrar productos por nombre
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para generar un reporte en Excel
        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Guardar Reporte de Productos";
                    saveFileDialog.FileName = "reporte_productos.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Aceptar la licencia de EPPlus para uso no comercial
                        //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        DataTable dt = (DataTable)dgvProductos.DataSource;

                        using (ExcelPackage excel = new ExcelPackage())
                        {
                            var ws = excel.Workbook.Worksheets.Add("Productos");
                            ws.Cells["A1"].LoadFromDataTable(dt, true);
                            FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                            excel.SaveAs(excelFile);
                            MessageBox.Show($"Reporte generado en {saveFileDialog.FileName}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento cuando se selecciona una fila en el DataGridView
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                // Asignar los valores de la fila seleccionada a los TextBox
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
                cmbCategorias.SelectedValue = row.Cells["CategoriaId"].Value;  // Seleccionar la categoría en el ComboBox
            }
        }

        private void ProductosForm_Load(object sender, EventArgs e)
        {

        }
    }
}