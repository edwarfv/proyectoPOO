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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;  // Configura el formulario como contenedor MDI
        }

        // Evento para abrir el formulario de productos
        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario ya está abierto
            if (Application.OpenForms["ProductosForm"] == null)
            {
                ProductosForm productosForm = new ProductosForm();
                productosForm.MdiParent = this;  // Establecer como formulario hijo del DashboardForm
                productosForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                Application.OpenForms["ProductosForm"].BringToFront();
            }
        }

        // Evento para abrir el formulario de ventas
        private void btnGestionVentas_Click(object sender, EventArgs e)
        {
            VentasForm ventasForm = new VentasForm();
            ventasForm.MdiParent = this;
            ventasForm.Show();
        }

        // Evento para abrir el formulario de clientes
        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            ClientesForm clientesForm = new ClientesForm();
            clientesForm.MdiParent = this;
            clientesForm.Show();
        }

        // Evento para abrir el formulario de proveedores
        private void btnGestionProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresForm proveedoresForm = new ProveedoresForm();
            proveedoresForm.MdiParent = this;
            proveedoresForm.Show();
        }

        // Evento para abrir el formulario de movimientos de inventario
        private void btnMovimientosInventario_Click(object sender, EventArgs e)
        {
            MovimientosInventarioForm movimientosForm = new MovimientosInventarioForm();
            movimientosForm.MdiParent = this;
            movimientosForm.Show();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Cargar automáticamente el formulario de Gestión de Ventas
            GestionVentasForm gestionVentasForm = new GestionVentasForm
            {
                MdiParent = this,  // Establecer el DashboardForm como el formulario padre
                Dock = DockStyle.Fill // Para que se ajuste automáticamente al espacio disponible
            };
            gestionVentasForm.Show();

        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación cuando se hace clic en la opción "Salir"
            Application.Exit();
        }

        private void movimientosDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario MovimientosInventarioForm ya está abierto
            if (Application.OpenForms["MovimientosInventarioForm"] == null)
            {
                MovimientosInventarioForm movimientosForm = new MovimientosInventarioForm();
                movimientosForm.MdiParent = this;  // Establecer como formulario hijo del DashboardForm (MDI)
                movimientosForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                Application.OpenForms["MovimientosInventarioForm"].BringToFront();
            }

        }
        private void gestionDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario VentasForm ya está abierto
            if (Application.OpenForms["GestionVentarForm"] == null)
            {
                GestionVentasForm GestionVentas = new GestionVentasForm();
                GestionVentas.MdiParent = this;  // Establecer como formulario hijo del DashboardForm (MDI)
                GestionVentas.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                Application.OpenForms["GestionVentarForm"].BringToFront();
            }
        }

        private void gestionDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario ProveedoresForm ya está abierto
            if (Application.OpenForms["ProveedoresForm"] == null)
            {
                ProveedoresForm proveedoresForm = new ProveedoresForm();
                proveedoresForm.MdiParent = this;  // Establecer como formulario hijo del DashboardForm (MDI)
                proveedoresForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                Application.OpenForms["ProveedoresForm"].BringToFront();
            }
        }

        private void gestionDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario ProductosForm ya está abierto
            if (Application.OpenForms["ProductosForm"] == null)
            {
                ProductosForm productosForm = new ProductosForm();
                productosForm.MdiParent = this;  // Establecer como formulario hijo del DashboardForm (MDI)
                productosForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                Application.OpenForms["ProductosForm"].BringToFront();
            }
        }

        private void gestionDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si el formulario ClientesForm ya está abierto
            if (Application.OpenForms["ClientesForm"] == null)
            {
                ClientesForm clientesForm = new ClientesForm();
                clientesForm.MdiParent = this;  // Establecer como formulario hijo del DashboardForm (MDI)
                clientesForm.Show();
            }
            else
            {
                // Traer el formulario al frente si ya está abierto
                Application.OpenForms["ClientesForm"].BringToFront();
            }
        }

        private void módulosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}