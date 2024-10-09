namespace SistemaInventarioVentas
{
    partial class PagosForm
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
            this.cmbVenta = new System.Windows.Forms.ComboBox();
            this.cmbMetodosPago = new System.Windows.Forms.ComboBox();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.btnEliminarPago = new System.Windows.Forms.Button();
            this.btnActualizarPago = new System.Windows.Forms.Button();
            this.btnAgregarPago = new System.Windows.Forms.Button();
            this.lblVentaAsociada = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.lblMontoPago = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVenta
            // 
            this.cmbVenta.FormattingEnabled = true;
            this.cmbVenta.Location = new System.Drawing.Point(27, 98);
            this.cmbVenta.Name = "cmbVenta";
            this.cmbVenta.Size = new System.Drawing.Size(198, 24);
            this.cmbVenta.TabIndex = 0;
            // 
            // cmbMetodosPago
            // 
            this.cmbMetodosPago.FormattingEnabled = true;
            this.cmbMetodosPago.Location = new System.Drawing.Point(27, 179);
            this.cmbMetodosPago.Name = "cmbMetodosPago";
            this.cmbMetodosPago.Size = new System.Drawing.Size(198, 24);
            this.cmbMetodosPago.TabIndex = 1;
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Location = new System.Drawing.Point(27, 258);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaPago.TabIndex = 2;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(27, 335);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(198, 22);
            this.txtMonto.TabIndex = 3;
            // 
            // dgvPagos
            // 
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Location = new System.Drawing.Point(277, 98);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.RowHeadersWidth = 51;
            this.dgvPagos.RowTemplate.Height = 24;
            this.dgvPagos.Size = new System.Drawing.Size(558, 259);
            this.dgvPagos.TabIndex = 4;
            // 
            // btnEliminarPago
            // 
            this.btnEliminarPago.Location = new System.Drawing.Point(565, 383);
            this.btnEliminarPago.Name = "btnEliminarPago";
            this.btnEliminarPago.Size = new System.Drawing.Size(101, 40);
            this.btnEliminarPago.TabIndex = 25;
            this.btnEliminarPago.Text = "Eliminar Pago";
            this.btnEliminarPago.UseVisualStyleBackColor = true;
            // 
            // btnActualizarPago
            // 
            this.btnActualizarPago.Location = new System.Drawing.Point(447, 383);
            this.btnActualizarPago.Name = "btnActualizarPago";
            this.btnActualizarPago.Size = new System.Drawing.Size(100, 40);
            this.btnActualizarPago.TabIndex = 24;
            this.btnActualizarPago.Text = "Actualizar Pago";
            this.btnActualizarPago.UseVisualStyleBackColor = true;
            // 
            // btnAgregarPago
            // 
            this.btnAgregarPago.Location = new System.Drawing.Point(331, 383);
            this.btnAgregarPago.Name = "btnAgregarPago";
            this.btnAgregarPago.Size = new System.Drawing.Size(101, 40);
            this.btnAgregarPago.TabIndex = 23;
            this.btnAgregarPago.Text = "Agregar Pago";
            this.btnAgregarPago.UseVisualStyleBackColor = true;
            // 
            // lblVentaAsociada
            // 
            this.lblVentaAsociada.AutoSize = true;
            this.lblVentaAsociada.Location = new System.Drawing.Point(24, 66);
            this.lblVentaAsociada.Name = "lblVentaAsociada";
            this.lblVentaAsociada.Size = new System.Drawing.Size(234, 16);
            this.lblVentaAsociada.TabIndex = 26;
            this.lblVentaAsociada.Text = "Seleccione la venta asociada al pago";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(24, 160);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(192, 16);
            this.lblMetodoPago.TabIndex = 27;
            this.lblMetodoPago.Text = "Seleccione el metodo de pago";
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Location = new System.Drawing.Point(24, 239);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(182, 16);
            this.lblFechaPago.TabIndex = 28;
            this.lblFechaPago.Text = "Seleccione la fecha del pago";
            // 
            // lblMontoPago
            // 
            this.lblMontoPago.AutoSize = true;
            this.lblMontoPago.Location = new System.Drawing.Point(24, 316);
            this.lblMontoPago.Name = "lblMontoPago";
            this.lblMontoPago.Size = new System.Drawing.Size(163, 16);
            this.lblMontoPago.TabIndex = 29;
            this.lblMontoPago.Text = "Ingrese el monto del pago";
            // 
            // PagosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 606);
            this.Controls.Add(this.lblMontoPago);
            this.Controls.Add(this.lblFechaPago);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.lblVentaAsociada);
            this.Controls.Add(this.btnEliminarPago);
            this.Controls.Add(this.btnActualizarPago);
            this.Controls.Add(this.btnAgregarPago);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.dtpFechaPago);
            this.Controls.Add(this.cmbMetodosPago);
            this.Controls.Add(this.cmbVenta);
            this.Name = "PagosForm";
            this.Text = "PagosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbVenta;
        private System.Windows.Forms.ComboBox cmbMetodosPago;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnEliminarPago;
        private System.Windows.Forms.Button btnActualizarPago;
        private System.Windows.Forms.Button btnAgregarPago;
        private System.Windows.Forms.Label lblVentaAsociada;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.Label lblMontoPago;
    }
}