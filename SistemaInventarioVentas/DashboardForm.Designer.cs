namespace SistemaInventarioVentas
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para la compatibilidad con el diseñador.
        /// No modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.módulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosDeInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // Habilitar el DashboardForm como contenedor MDI
            this.IsMdiContainer = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.módulosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1175, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // módulosToolStripMenuItem
            // 
            this.módulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeProductosToolStripMenuItem,
            this.gestiónDeVentasToolStripMenuItem,
            this.gestiónDeClientesToolStripMenuItem,
            this.gestiónDeProveedoresToolStripMenuItem,
            this.movimientosDeInventarioToolStripMenuItem});
            this.módulosToolStripMenuItem.Name = "módulosToolStripMenuItem";
            this.módulosToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.módulosToolStripMenuItem.Text = "Módulos";
            this.módulosToolStripMenuItem.Click += new System.EventHandler(this.módulosToolStripMenuItem_Click);
            // 
            // gestiónDeProductosToolStripMenuItem
            // 
            this.gestiónDeProductosToolStripMenuItem.Name = "gestiónDeProductosToolStripMenuItem";
            this.gestiónDeProductosToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.gestiónDeProductosToolStripMenuItem.Text = "Gestión de Productos";
            this.gestiónDeProductosToolStripMenuItem.Click += new System.EventHandler(this.gestionDeProductosToolStripMenuItem_Click);
            // 
            // gestiónDeVentasToolStripMenuItem
            // 
            this.gestiónDeVentasToolStripMenuItem.Name = "gestiónDeVentasToolStripMenuItem";
            this.gestiónDeVentasToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.gestiónDeVentasToolStripMenuItem.Text = "Gestión de Ventas";
            this.gestiónDeVentasToolStripMenuItem.Click += new System.EventHandler(this.gestionDeVentasToolStripMenuItem_Click);
            // 
            // gestiónDeClientesToolStripMenuItem
            // 
            this.gestiónDeClientesToolStripMenuItem.Name = "gestiónDeClientesToolStripMenuItem";
            this.gestiónDeClientesToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.gestiónDeClientesToolStripMenuItem.Text = "Gestión de Clientes";
            this.gestiónDeClientesToolStripMenuItem.Click += new System.EventHandler(this.gestionDeClientesToolStripMenuItem_Click);
            // 
            // gestiónDeProveedoresToolStripMenuItem
            // 
            this.gestiónDeProveedoresToolStripMenuItem.Name = "gestiónDeProveedoresToolStripMenuItem";
            this.gestiónDeProveedoresToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.gestiónDeProveedoresToolStripMenuItem.Text = "Gestión de Proveedores";
            this.gestiónDeProveedoresToolStripMenuItem.Click += new System.EventHandler(this.gestionDeProveedoresToolStripMenuItem_Click);
            // 
            // movimientosDeInventarioToolStripMenuItem
            // 
            this.movimientosDeInventarioToolStripMenuItem.Name = "movimientosDeInventarioToolStripMenuItem";
            this.movimientosDeInventarioToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
            this.movimientosDeInventarioToolStripMenuItem.Text = "Movimientos de Inventario";
            this.movimientosDeInventarioToolStripMenuItem.Click += new System.EventHandler(this.movimientosDeInventarioToolStripMenuItem_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 683);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem módulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimientosDeInventarioToolStripMenuItem;
    }
}
