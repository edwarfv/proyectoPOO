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
    public partial class Form1 : Form
    {
        private BaseDatos db = new BaseDatos(); 
        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        // Método para limpiar los campos de entrada
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtBuscar.Clear();
        }
        private void CargarProductos()
        {
            dgvProductos.DataSource = db.ObtenerProductos(); // Obtener todos los productos de la base de datos
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var producto = new Producto(txtNombre.Text, decimal.Parse(txtPrecio.Text), int.Parse(txtCantidad.Text));
            db.AgregarProducto(producto);
            CargarProductos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay alguna fila seleccionada
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    // Obtener los valores de la fila seleccionada
                    var producto = new Producto
                    {
                        Id = int.Parse(dgvProductos.SelectedRows[0].Cells[0].Value.ToString()),
                        Nombre = txtNombre.Text,
                        Precio = decimal.Parse(txtPrecio.Text),
                        Cantidad = int.Parse(txtCantidad.Text)
                    };

                    // Actualizar el producto en la base de datos
                    db.ActualizarProducto(producto);

                    // Recargar los productos en el DataGridView
                    CargarProductos();
                    LimpiarCampos();

                    MessageBox.Show("Producto actualizado correctamente.");
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila para actualizar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay alguna fila seleccionada
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    // Obtener el Id del producto seleccionado
                    int id = int.Parse(dgvProductos.SelectedRows[0].Cells[0].Value.ToString());

                    // Eliminar el producto de la base de datos
                    db.EliminarProducto(id);

                    // Recargar los productos en el DataGridView
                    CargarProductos();
                    LimpiarCampos();

                    MessageBox.Show("Producto eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una fila para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
            }
        }


      /*  private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                // Si el campo de búsqueda está vacío, mostrar todos los productos
                CargarProductos();
            }
            else
            {
                // Si hay texto en el campo de búsqueda, buscar los productos
                dgvProductos.DataSource = db.BuscarProductos(txtBuscar.Text);
            }
        }*/

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Si el campo de búsqueda está vacío, cargar todos los productos
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                CargarProductos(); // Mostrar todos los productos
            }
            else
            {
                // Buscar los productos cuyo nombre coincida con lo escrito en txtBuscar
                dgvProductos.DataSource = db.BuscarProductos(txtBuscar.Text);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                // Aceptar la licencia de EPPlus para uso no comercial
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                DataTable dt = (DataTable)dgvProductos.DataSource;

                using (ExcelPackage excel = new ExcelPackage())
                {
                    var ws = excel.Workbook.Worksheets.Add("Productos");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    FileInfo excelFile = new FileInfo(@"C:\Users\edwar\Documents\PPO\ProgramacionOrientadaObjeto\Proyecto_final\reporte_productos.xlsx");
                    excel.SaveAs(excelFile);
                    MessageBox.Show("Reporte generado enC:\\Users\\edwar\\Documents\\PPO\\ProgramacionOrientadaObjeto\\Proyecto_final\\reporte_productos.xlsx");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la fila seleccionada es válida
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                // Asigna los valores de la fila seleccionada a los TextBox
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
