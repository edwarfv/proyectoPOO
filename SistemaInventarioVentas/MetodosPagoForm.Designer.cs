namespace SistemaInventarioVentas
{
    partial class MetodosPagoForm
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
            this.components = new System.ComponentModel.Container();
            this.txtMetodoPago = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvMetodosPago = new System.Windows.Forms.DataGridView();
            this.btnEliminarMetodoPago = new System.Windows.Forms.Button();
            this.btnActualizarMetodoPago = new System.Windows.Forms.Button();
            this.btnAgregarMetodoPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodosPago)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMetodoPago
            // 
            this.txtMetodoPago.Location = new System.Drawing.Point(25, 96);
            this.txtMetodoPago.Name = "txtMetodoPago";
            this.txtMetodoPago.Size = new System.Drawing.Size(245, 22);
            this.txtMetodoPago.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dgvMetodosPago
            // 
            this.dgvMetodosPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetodosPago.Location = new System.Drawing.Point(327, 96);
            this.dgvMetodosPago.Name = "dgvMetodosPago";
            this.dgvMetodosPago.RowHeadersWidth = 51;
            this.dgvMetodosPago.RowTemplate.Height = 24;
            this.dgvMetodosPago.Size = new System.Drawing.Size(399, 212);
            this.dgvMetodosPago.TabIndex = 2;
            // 
            // btnEliminarMetodoPago
            // 
            this.btnEliminarMetodoPago.Location = new System.Drawing.Point(577, 314);
            this.btnEliminarMetodoPago.Name = "btnEliminarMetodoPago";
            this.btnEliminarMetodoPago.Size = new System.Drawing.Size(116, 40);
            this.btnEliminarMetodoPago.TabIndex = 31;
            this.btnEliminarMetodoPago.Text = "Eliminar metodo de pago";
            this.btnEliminarMetodoPago.UseVisualStyleBackColor = true;
            // 
            // btnActualizarMetodoPago
            // 
            this.btnActualizarMetodoPago.Location = new System.Drawing.Point(452, 314);
            this.btnActualizarMetodoPago.Name = "btnActualizarMetodoPago";
            this.btnActualizarMetodoPago.Size = new System.Drawing.Size(119, 40);
            this.btnActualizarMetodoPago.TabIndex = 30;
            this.btnActualizarMetodoPago.Text = "Actualizar metodo de pago";
            this.btnActualizarMetodoPago.UseVisualStyleBackColor = true;
            // 
            // btnAgregarMetodoPago
            // 
            this.btnAgregarMetodoPago.Location = new System.Drawing.Point(327, 314);
            this.btnAgregarMetodoPago.Name = "btnAgregarMetodoPago";
            this.btnAgregarMetodoPago.Size = new System.Drawing.Size(119, 40);
            this.btnAgregarMetodoPago.TabIndex = 29;
            this.btnAgregarMetodoPago.Text = "Agregar metodo de pago";
            this.btnAgregarMetodoPago.UseVisualStyleBackColor = true;
            // 
            // MetodosPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 608);
            this.Controls.Add(this.btnEliminarMetodoPago);
            this.Controls.Add(this.btnActualizarMetodoPago);
            this.Controls.Add(this.btnAgregarMetodoPago);
            this.Controls.Add(this.dgvMetodosPago);
            this.Controls.Add(this.txtMetodoPago);
            this.Name = "MetodosPagoForm";
            this.Text = "MetodosPagoForm";
  //          this.Load += new System.EventHandler(this.MetodosPagoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetodosPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMetodoPago;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvMetodosPago;
        private System.Windows.Forms.Button btnEliminarMetodoPago;
        private System.Windows.Forms.Button btnActualizarMetodoPago;
        private System.Windows.Forms.Button btnAgregarMetodoPago;
    }
}