using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;



namespace SistemaInventarioVentas
{
    public partial class GestionVentasForm : Form
    {
        private BaseDatos db = new BaseDatos();

        public GestionVentasForm()
        {
            InitializeComponent();
            ConfigurarDataGridViewCarrito();
            CargarClientes();
            CargarProductos();

            // Hacer que txtTotalVenta no sea editable
            txtTotalVenta.ReadOnly = true;
            txtTotalVenta.Enabled = false; // Deshabilitar completamente el campo
        }

        private void ConfigurarDataGridViewCarrito()
        {
            dgvCarrito.Columns.Clear();

            dgvCarrito.Columns.Add("ProductoId", "ID Producto");
            dgvCarrito.Columns.Add("NombreProducto", "Nombre del Producto");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvCarrito.Columns.Add("Descuento", "Descuento");
            dgvCarrito.Columns.Add("Total", "Total");

            dgvCarrito.Columns["ProductoId"].ValueType = typeof(int);
            dgvCarrito.Columns["Cantidad"].ValueType = typeof(int);
            dgvCarrito.Columns["PrecioUnitario"].ValueType = typeof(decimal);
            dgvCarrito.Columns["Descuento"].ValueType = typeof(decimal);
            dgvCarrito.Columns["Total"].ValueType = typeof(decimal);
        }

        private void GestionVentasForm_Load(object sender, EventArgs e)
        {

        }

        private void CargarClientes()
        {
            try
            {
                DataTable dtClientes = db.ObtenerClientes();
                cmbCliente.DataSource = dtClientes;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}");
            }
        }

        private void CargarProductos()
        {
            try
            {
                DataTable dtProductos = db.ObtenerProductos();
                cmbProductos.DataSource = dtProductos;
                cmbProductos.DisplayMember = "Nombre";
                cmbProductos.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}");
            }
        }

        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProductos.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int productoId = (int)cmbProductos.SelectedValue;
                string nombreProducto = cmbProductos.Text;
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precioUnitario = db.ObtenerPrecioProducto(productoId);
                decimal descuento = string.IsNullOrWhiteSpace(txtDescuento.Text) ? 0 : decimal.Parse(txtDescuento.Text);
                

                if (cantidad > db.ObtenerCantidadProducto(productoId))
                {
                    MessageBox.Show("No hay suficiente inventario disponible.");
                    return;
                }

                decimal total = (cantidad * precioUnitario) - descuento;

                dgvCarrito.Rows.Add(productoId, nombreProducto, cantidad, precioUnitario, descuento, total);
                CalcularTotalVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar al carrito: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarCarrito_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCarrito.SelectedRows[0];
                row.Cells["Cantidad"].Value = txtCantidad.Text;
                row.Cells["Descuento"].Value = txtDescuento.Text;
                decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                int cantidad = int.Parse(txtCantidad.Text);
                decimal descuento = string.IsNullOrWhiteSpace(txtDescuento.Text) ? 0 : decimal.Parse(txtDescuento.Text);
                decimal total = (cantidad * precioUnitario) - descuento;
                row.Cells["Total"].Value = total;

                CalcularTotalVenta();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para actualizar.");
            }
        }

        private void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count > 0)
            {
                dgvCarrito.Rows.Remove(dgvCarrito.SelectedRows[0]);
                CalcularTotalVenta();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar del carrito.");
            }
        }

        /*private void CalcularTotalVenta()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Total"].Value);
                }
            }
            txtTotalVenta.Text = total.ToString("N2");
        }*/
        private void CalcularTotalVenta()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    // Asegúrate de que puedes convertir el valor a decimal de forma segura.
                    decimal valorTotal;
                    bool conversionExitosa = decimal.TryParse(row.Cells["Total"].Value.ToString(), out valorTotal);

                    if (conversionExitosa)
                    {
                        total += valorTotal;
                    }
                    else
                    {
                        MessageBox.Show("Error al convertir el valor total de una fila. Asegúrate de que todos los valores ingresados son correctos.", "Error de Conversión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Establecer el valor total en el TextBox, pero asegúrate de deshabilitarlo para que no sea editable.
            txtTotalVenta.Text = total.ToString("N2", CultureInfo.InvariantCulture);
            txtTotalVenta.Enabled = false; // Asegúrate de que el TextBox no pueda ser editado.
        }


        /*private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCarrito.Rows.Count == 0)
                {
                    MessageBox.Show("El carrito está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int clienteId = (int)cmbCliente.SelectedValue;
                DateTime fechaVenta = dtpFechaVenta.Value;
                decimal totalVenta = decimal.Parse(txtTotalVenta.Text);
                // Guardar la venta en la base de datos
                int ventaId = db.AgregarVenta(clienteId, fechaVenta, totalVenta);



                // Recorrer el carrito y agregar los detalles de la venta
                foreach (DataGridViewRow row in dgvCarrito.Rows)
                {
                    // Omitir la fila nueva (que aparece para ingresar nuevos datos)
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    // Verificar que todas las celdas necesarias tengan valores antes de acceder
                    if (row.Cells["ProductoId"].Value != null &&
                        row.Cells["Cantidad"].Value != null &&
                        row.Cells["PrecioUnitario"].Value != null &&
                        row.Cells["Descuento"].Value != null &&
                        row.Cells["Total"].Value != null)
                    {
                        try
                        {
                            int productoId = Convert.ToInt32(row.Cells["ProductoId"].Value);
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                            decimal descuento = Convert.ToDecimal(row.Cells["Descuento"].Value);
                            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                            // Agregar detalle de venta
                            db.AgregarDetalleVenta(clienteId, productoId, cantidad, precioUnitario, descuento, total);

                            // Registrar movimiento de inventario
                            db.RegistrarMovimientoVenta(productoId, cantidad, fechaVenta);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al procesar la fila del producto ID {row.Cells["ProductoId"].Value}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Algunas celdas en el carrito no tienen valores válidos. Por favor, revise los datos antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                //GenerarFacturaPDF(clienteId, fechaVenta, totalVenta);
                //decimal totalVenta = decimal.Parse(txtTotalVenta.Text); // Obtener el valor total desde el textbox correspondiente
                try
                {
                    // Eliminar la declaración redundante de `totalVenta`
                    totalVenta = decimal.Parse(txtTotalVenta.Text); // Asignar el valor al totalVenta existente

                    // Generar la factura con la información correcta
                    GenerarFacturaPDF(clienteId, ventaId, fechaVenta, totalVenta);
                    MessageBox.Show("Venta registrada y factura generada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar la factura: {ex.Message}");
                }
                GenerarFacturaPDF(clienteId, ventaId, fechaVenta, totalVenta);
                MessageBox.Show("Venta registrada y factura generada correctamente.");
            }
                catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura: {ex.Message}");
            }
        }
        */
        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                // Eliminar la declaración redundante de `totalVenta`
                decimal totalVenta;

                // Usar decimal.TryParse para evitar errores de conversión
                if (decimal.TryParse(txtTotalVenta.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out totalVenta))
                {
                    // Generar la factura con la información correcta
                    GenerarFacturaPDF(clienteId, ventaId, fechaVenta, totalVenta);
                    MessageBox.Show("Venta registrada y factura generada correctamente.");
                }
                else
                {
                    MessageBox.Show("El valor del total de la venta no tiene el formato correcto. Por favor, revise los valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                */

                int clienteId = (int)cmbCliente.SelectedValue;
                DateTime fechaVenta = dtpFechaVenta.Value;
                decimal totalVenta;

                // Usar decimal.TryParse para evitar errores de conversión
                if (decimal.TryParse(txtTotalVenta.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out totalVenta))
                {

                    // Registrar la venta en la base de datos y obtener el ID de la venta
                    int ventaId = db.AgregarVenta(clienteId, fechaVenta, totalVenta);

                    // Agregar cada producto del carrito como detalle de la venta
                    foreach (DataGridViewRow row in dgvCarrito.Rows)
                    {
                        if (row.IsNewRow) continue; // Omitir la fila vacía del DataGridView

                        int productoId = Convert.ToInt32(row.Cells["ProductoId"].Value);
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        decimal precioUnitario = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value);
                        decimal descuento = Convert.ToDecimal(row.Cells["Descuento"].Value);
                        decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                        // Llama al método para agregar el detalle de la venta
                        db.AgregarDetalleVenta(ventaId, productoId, cantidad, precioUnitario, descuento, total);

                        // Actualizar la cantidad del producto en inventario
                        int cantidadActual = db.ObtenerCantidadProducto(productoId);
                        int nuevaCantidad = cantidadActual - cantidad;
                        db.ActualizarCantidadProducto(productoId, nuevaCantidad);

                        // Registrar el movimiento de inventario para la venta
                        db.RegistrarMovimientoVenta(productoId, cantidad, fechaVenta, "Venta a Cliente");

                        // Verificación para asegurar que se registre correctamente
                        if (nuevaCantidad < 0)
                        {
                            MessageBox.Show($"El producto {row.Cells["NombreProducto"].Value} tiene inventario insuficiente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                
                    // Generar la factura con la información correcta
                    GenerarFacturaPDF(clienteId, ventaId, fechaVenta, totalVenta);
                    MessageBox.Show("Venta registrada y factura generada correctamente.");
                }
                else
                {
                    MessageBox.Show("El valor del total de la venta no tiene el formato correcto. Por favor, revise los valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        /*private void GenerarFacturaPDF(int clienteId, int ventaId, DateTime fechaVenta, decimal totalVenta)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream($"Factura_Venta_{ventaId}.pdf", FileMode.Create));
                doc.Open();
                doc.Add(new Paragraph($"Factura de Venta - Nro: {ventaId}"));
                doc.Add(new Paragraph($"Cliente ID: {clienteId}"));
                doc.Add(new Paragraph($"Fecha de Venta: {fechaVenta.ToShortDateString()}"));
                doc.Add(new Paragraph($"Total Venta: {totalVenta:C}"));
                doc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}");
            }
        }*/
        private void GenerarFacturaPDF(int clienteId, int ventaId, DateTime fechaVenta, decimal totalVenta)
        {
            try
            {
                // Usar SaveFileDialog para que el usuario seleccione la ubicación de guardado
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.FileName = $"Factura_Venta_{ventaId}_{fechaVenta:yyyyMMdd}.pdf";
                    saveFileDialog.Title = "Guardar Factura como";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = saveFileDialog.FileName;

                        // Obtener información del cliente desde la base de datos
                        var cliente = db.ObtenerClientePorId(clienteId);
                        if (cliente == null)
                        {
                            MessageBox.Show("No se pudo encontrar la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        /*
                        // Obtener información del cliente desde la base de datos
                        var cliente = db.ObtenerClientePorId(clienteId);
                        if (cliente == null)
                        {
                            MessageBox.Show("No se pudo encontrar la información del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        */

                        // Crear el documento PDF
                        Document doc = new Document(PageSize.A4, 50, 50, 25, 25);
                        //string fileName = $"Factura_Venta_{ventaId}_{fechaVenta:yyyyMMdd}.pdf";
                        PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
                        doc.Open();

                        // Encabezado de la factura
                        var titulo = new Paragraph("Factura de Venta", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                        titulo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(titulo);
                        doc.Add(new Paragraph("\n"));

                        // Información de la empresa
                        var empresaInfo = new Paragraph("Empresa XYZ\nDirección: Calle Falsa 123, Ciudad\nTeléfono: (555) 555-5555\nCorreo: contacto@empresa.com\n\n",
                            FontFactory.GetFont(FontFactory.HELVETICA, 12));
                        empresaInfo.Alignment = Element.ALIGN_LEFT;
                        doc.Add(empresaInfo);

                        // Información del cliente
                        var clienteInfo = new Paragraph($"Cliente:\nNombre: {cliente.Nombre}\nEmail: {cliente.Email}\nTeléfono: {cliente.Telefono}\nDirección: {cliente.Direccion}\n\n",
                            FontFactory.GetFont(FontFactory.HELVETICA, 12));
                        clienteInfo.Alignment = Element.ALIGN_LEFT;
                        doc.Add(clienteInfo);

                        // Información de la venta
                        var ventaInfo = new Paragraph($"Factura de Venta - Nro: {ventaId}\nFecha de Venta: {fechaVenta.ToShortDateString()}\n\n",
                            FontFactory.GetFont(FontFactory.HELVETICA, 12));
                        ventaInfo.Alignment = Element.ALIGN_LEFT;
                        doc.Add(ventaInfo);

                        // Crear la tabla de productos
                        PdfPTable table = new PdfPTable(5);
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 10, 40, 10, 20, 20 });

                        // Encabezados de la tabla
                        table.AddCell(new PdfPCell(new Phrase("ID Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase("Nombre del Producto", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase("Cantidad", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase("Precio Unitario", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        table.AddCell(new PdfPCell(new Phrase("Subtotal", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12))) { HorizontalAlignment = Element.ALIGN_CENTER });

                        // Obtener los detalles de la venta desde la base de datos
                        var detallesVenta = db.ObtenerDetallesVenta(ventaId);

                        // Iterar sobre las filas del DataTable
                        foreach (DataRow detalle in detallesVenta.Rows)
                        {
                            // Extraer la información de cada columna de la fila
                            int productoId = Convert.ToInt32(detalle["ProductoId"]);
                            string nombreProducto = detalle["Producto"].ToString();
                            int cantidad = Convert.ToInt32(detalle["Cantidad"]);
                            //decimal precioUnitario = Convert.ToDecimal(detalle["PrecioUnitario"]);
                            //decimal descuento = Convert.ToDecimal(detalle["Descuento"]);
                            //decimal subtotal = cantidad * precioUnitario - descuento;
                            // Convertir precio unitario y descuento de manera segura
                            if (!decimal.TryParse(detalle["PrecioUnitario"].ToString(), out decimal precioUnitario))
                            {
                                MessageBox.Show("Error al convertir el precio unitario. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            decimal descuento = 0;
                            if (!string.IsNullOrWhiteSpace(detalle["Descuento"].ToString()))
                            {
                                if (!decimal.TryParse(detalle["Descuento"].ToString(), out descuento))
                                {
                                    MessageBox.Show("Error al convertir el descuento. Verifique los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }

                            decimal subtotal = (cantidad * precioUnitario) - descuento;

                            // Añadir las celdas con la información extraída a la tabla del PDF
                            table.AddCell(new PdfPCell(new Phrase(productoId.ToString())) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase(nombreProducto)) { HorizontalAlignment = Element.ALIGN_LEFT });
                            table.AddCell(new PdfPCell(new Phrase(cantidad.ToString())) { HorizontalAlignment = Element.ALIGN_CENTER });
                            table.AddCell(new PdfPCell(new Phrase($"{precioUnitario:C}")) { HorizontalAlignment = Element.ALIGN_RIGHT });
                            table.AddCell(new PdfPCell(new Phrase($"{subtotal:C}")) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        }

                        // Agregar la tabla al documento
                        doc.Add(table);

                        // Mostrar el total de la venta
                        var totalVentaInfo = new Paragraph($"\nTotal Venta: {totalVenta:C}\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                        totalVentaInfo.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(totalVentaInfo);

                        // Pie de página o agradecimiento
                        var agradecimiento = new Paragraph("Gracias por su compra.\n\n", FontFactory.GetFont(FontFactory.HELVETICA, 12));
                        agradecimiento.Alignment = Element.ALIGN_CENTER;
                        doc.Add(agradecimiento);

                        // Cerrar el documento
                        doc.Close();

                        // Notificar al usuario que la factura se ha generado correctamente
                        MessageBox.Show($"Factura generada correctamente: {fileName}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCarrito_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCarrito.SelectedRows[0];

                // Obtener los valores de la fila seleccionada
                int productoId = (int)selectedRow.Cells["ProductoId"].Value;
                string nombreProducto = selectedRow.Cells["NombreProducto"].Value.ToString();
                int cantidad = (int)selectedRow.Cells["Cantidad"].Value;
                decimal precioUnitario = (decimal)selectedRow.Cells["PrecioUnitario"].Value;
                decimal descuento = (decimal)selectedRow.Cells["Descuento"].Value;

                // Asignar los valores a los campos correspondientes
                cmbProductos.SelectedValue = productoId;
                txtCantidad.Text = cantidad.ToString();
                txtDescuento.Text = descuento.ToString();
            }
        }
    }
}
    

