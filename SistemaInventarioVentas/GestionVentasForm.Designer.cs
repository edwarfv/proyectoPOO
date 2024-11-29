namespace SistemaInventarioVentas
{
    partial class GestionVentasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.txtTotalVenta = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.btnActualizarCarrito = new System.Windows.Forms.Button();
            this.btnEliminarDelCarrito = new System.Windows.Forms.Button();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(12, 118);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(255, 24);
            this.cmbCliente.TabIndex = 0;
            // 
            // cmbProductos
            // 
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(12, 207);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(255, 24);
            this.cmbProductos.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(12, 89);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(169, 20);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Seleccionar el cliente";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(12, 175);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(149, 16);
            this.lblProducto.TabIndex = 3;
            this.lblProducto.Text = "Seleccionar el producto";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(12, 278);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(255, 22);
            this.txtCantidad.TabIndex = 4;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(12, 248);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(254, 20);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Ingrese la cantidad de productos";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(12, 342);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(254, 22);
            this.txtDescuento.TabIndex = 6;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(12, 313);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(165, 20);
            this.lblDescuento.TabIndex = 7;
            this.lblDescuento.Text = "Ingrese el descuento";
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.Location = new System.Drawing.Point(12, 406);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Size = new System.Drawing.Size(255, 22);
            this.dtpFechaVenta.TabIndex = 8;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 378);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(213, 20);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Seleccionar fecha de venta";
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(403, 89);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.RowTemplate.Height = 24;
            this.dgvCarrito.Size = new System.Drawing.Size(806, 319);
            this.dgvCarrito.TabIndex = 10;
            this.dgvCarrito.SelectionChanged += new System.EventHandler(this.dgvCarrito_SelectionChanged);
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.Location = new System.Drawing.Point(15, 487);
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.Size = new System.Drawing.Size(251, 22);
            this.txtTotalVenta.TabIndex = 11;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 464);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 16);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Total Venta";
            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.Location = new System.Drawing.Point(403, 430);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new System.Drawing.Size(112, 50);
            this.btnAgregarAlCarrito.TabIndex = 13;
            this.btnAgregarAlCarrito.Text = "Agregar al carrito";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = true;
            this.btnAgregarAlCarrito.Click += new System.EventHandler(this.btnAgregarAlCarrito_Click);
            // 
            // btnActualizarCarrito
            // 
            this.btnActualizarCarrito.Location = new System.Drawing.Point(521, 430);
            this.btnActualizarCarrito.Name = "btnActualizarCarrito";
            this.btnActualizarCarrito.Size = new System.Drawing.Size(117, 50);
            this.btnActualizarCarrito.TabIndex = 14;
            this.btnActualizarCarrito.Text = "Actualizar carrito";
            this.btnActualizarCarrito.UseVisualStyleBackColor = true;
            this.btnActualizarCarrito.Click += new System.EventHandler(this.btnActualizarCarrito_Click);
            // 
            // btnEliminarDelCarrito
            // 
            this.btnEliminarDelCarrito.Location = new System.Drawing.Point(654, 430);
            this.btnEliminarDelCarrito.Name = "btnEliminarDelCarrito";
            this.btnEliminarDelCarrito.Size = new System.Drawing.Size(123, 50);
            this.btnEliminarDelCarrito.TabIndex = 15;
            this.btnEliminarDelCarrito.Text = "Eliminar del carrito";
            this.btnEliminarDelCarrito.UseVisualStyleBackColor = true;
            this.btnEliminarDelCarrito.Click += new System.EventHandler(this.btnEliminarDelCarrito_Click);
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Location = new System.Drawing.Point(403, 487);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(112, 53);
            this.btnGenerarFactura.TabIndex = 16;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // GestionVentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 614);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.btnEliminarDelCarrito);
            this.Controls.Add(this.btnActualizarCarrito);
            this.Controls.Add(this.btnAgregarAlCarrito);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotalVenta);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFechaVenta);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.cmbCliente);
            this.Name = "GestionVentasForm";
            this.Text = "GestionVentasForm";
            this.Load += new System.EventHandler(this.GestionVentasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.TextBox txtTotalVenta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAgregarAlCarrito;
        private System.Windows.Forms.Button btnActualizarCarrito;
        private System.Windows.Forms.Button btnEliminarDelCarrito;
        private System.Windows.Forms.Button btnGenerarFactura;
    }
}