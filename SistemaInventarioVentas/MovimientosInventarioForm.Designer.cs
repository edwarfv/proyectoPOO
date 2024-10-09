namespace SistemaInventarioVentas
{
    partial class MovimientosInventarioForm
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
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.dgvMovimientosInventario = new System.Windows.Forms.DataGridView();
            this.btnEliminarMovimiento = new System.Windows.Forms.Button();
            this.btnActualizarMovimiento = new System.Windows.Forms.Button();
            this.btnAgregarMovimiento = new System.Windows.Forms.Button();
            this.lblFechaMovimiento = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblTipoMovimiento = new System.Windows.Forms.Label();
            this.lblCantidadMovimiento = new System.Windows.Forms.Label();
            this.lblDescripciónMovimiento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientosInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(27, 186);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(272, 24);
            this.cmbProducto.TabIndex = 0;
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(27, 256);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(272, 24);
            this.cmbTipoMovimiento.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(27, 318);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(272, 22);
            this.txtCantidad.TabIndex = 3;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(27, 118);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(272, 22);
            this.dtpFecha.TabIndex = 4;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(27, 382);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(272, 22);
            this.txtMotivo.TabIndex = 5;
            // 
            // dgvMovimientosInventario
            // 
            this.dgvMovimientosInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientosInventario.Location = new System.Drawing.Point(438, 109);
            this.dgvMovimientosInventario.Name = "dgvMovimientosInventario";
            this.dgvMovimientosInventario.RowHeadersWidth = 51;
            this.dgvMovimientosInventario.RowTemplate.Height = 24;
            this.dgvMovimientosInventario.Size = new System.Drawing.Size(591, 286);
            this.dgvMovimientosInventario.TabIndex = 6;
            // 
            // btnEliminarMovimiento
            // 
            this.btnEliminarMovimiento.Location = new System.Drawing.Point(686, 414);
            this.btnEliminarMovimiento.Name = "btnEliminarMovimiento";
            this.btnEliminarMovimiento.Size = new System.Drawing.Size(101, 40);
            this.btnEliminarMovimiento.TabIndex = 28;
            this.btnEliminarMovimiento.Text = "Eliminar Movimiento";
            this.btnEliminarMovimiento.UseVisualStyleBackColor = true;
            // 
            // btnActualizarMovimiento
            // 
            this.btnActualizarMovimiento.Location = new System.Drawing.Point(568, 414);
            this.btnActualizarMovimiento.Name = "btnActualizarMovimiento";
            this.btnActualizarMovimiento.Size = new System.Drawing.Size(100, 40);
            this.btnActualizarMovimiento.TabIndex = 27;
            this.btnActualizarMovimiento.Text = "Actualizar Movimiento";
            this.btnActualizarMovimiento.UseVisualStyleBackColor = true;
            // 
            // btnAgregarMovimiento
            // 
            this.btnAgregarMovimiento.Location = new System.Drawing.Point(452, 414);
            this.btnAgregarMovimiento.Name = "btnAgregarMovimiento";
            this.btnAgregarMovimiento.Size = new System.Drawing.Size(101, 40);
            this.btnAgregarMovimiento.TabIndex = 26;
            this.btnAgregarMovimiento.Text = "Agregar Movimiento";
            this.btnAgregarMovimiento.UseVisualStyleBackColor = true;
            // 
            // lblFechaMovimiento
            // 
            this.lblFechaMovimiento.AutoSize = true;
            this.lblFechaMovimiento.Location = new System.Drawing.Point(24, 89);
            this.lblFechaMovimiento.Name = "lblFechaMovimiento";
            this.lblFechaMovimiento.Size = new System.Drawing.Size(336, 20);
            this.lblFechaMovimiento.TabIndex = 29;
            this.lblFechaMovimiento.Text = "Seleccione la fecha la fecha del movimiento";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(24, 163);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(145, 16);
            this.lblProducto.TabIndex = 30;
            this.lblProducto.Text = "Seleccione el producto";
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.Location = new System.Drawing.Point(24, 237);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.Size = new System.Drawing.Size(395, 20);
            this.lblTipoMovimiento.TabIndex = 31;
            this.lblTipoMovimiento.Text = "Seleccione el tipo de movimiento (Entrada o Salida)";
            // 
            // lblCantidadMovimiento
            // 
            this.lblCantidadMovimiento.AutoSize = true;
            this.lblCantidadMovimiento.Location = new System.Drawing.Point(24, 299);
            this.lblCantidadMovimiento.Name = "lblCantidadMovimiento";
            this.lblCantidadMovimiento.Size = new System.Drawing.Size(269, 20);
            this.lblCantidadMovimiento.TabIndex = 32;
            this.lblCantidadMovimiento.Text = "Ingrese la cantidad del movimiento";
            // 
            // lblDescripciónMovimiento
            // 
            this.lblDescripciónMovimiento.AutoSize = true;
            this.lblDescripciónMovimiento.Location = new System.Drawing.Point(24, 363);
            this.lblDescripciónMovimiento.Name = "lblDescripciónMovimiento";
            this.lblDescripciónMovimiento.Size = new System.Drawing.Size(216, 20);
            this.lblDescripciónMovimiento.TabIndex = 33;
            this.lblDescripciónMovimiento.Text = "Descripción del movimiento";
            // 
            // MovimientosInventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 620);
            this.Controls.Add(this.lblDescripciónMovimiento);
            this.Controls.Add(this.lblCantidadMovimiento);
            this.Controls.Add(this.lblTipoMovimiento);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblFechaMovimiento);
            this.Controls.Add(this.btnEliminarMovimiento);
            this.Controls.Add(this.btnActualizarMovimiento);
            this.Controls.Add(this.btnAgregarMovimiento);
            this.Controls.Add(this.dgvMovimientosInventario);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbTipoMovimiento);
            this.Controls.Add(this.cmbProducto);
            this.Name = "MovimientosInventarioForm";
            this.Text = "MovimientosInventarioForm";
            this.Load += new System.EventHandler(this.MovimientosInventarioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientosInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.DataGridView dgvMovimientosInventario;
        private System.Windows.Forms.Button btnEliminarMovimiento;
        private System.Windows.Forms.Button btnActualizarMovimiento;
        private System.Windows.Forms.Button btnAgregarMovimiento;
        private System.Windows.Forms.Label lblFechaMovimiento;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private System.Windows.Forms.Label lblCantidadMovimiento;
        private System.Windows.Forms.Label lblDescripciónMovimiento;
    }
}