using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // cnx BD
using System.Data;//cnx BD

namespace SistemaInventarioVentas
{
    internal class BaseDatos
    {
        private string connectionString = "server=localhost;database=InventarioDB;uid=root;pwd=Edwar5420*;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(connectionString);
        }

        // Métodos para Producto
        public DataTable ObtenerProductos()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Productos", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AgregarProducto(Producto producto)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Productos (Nombre, Precio, Cantidad) VALUES (@nombre, @precio, @cantidad)", conn);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarProducto(Producto producto)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Productos SET Nombre = @nombre, Precio = @precio, Cantidad = @cantidad WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProducto(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Productos WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para buscar productos
        public DataTable BuscarProductos(string filtro)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Productos WHERE Nombre LIKE @filtro", conn);
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Método para validar usuarios
        public bool ValidarUsuario(string username, string password)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT COUNT(1) FROM Usuarios WHERE Username = @username AND Password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
        }

        // Método para obtener la lista de clientes
        public DataTable ObtenerClientes()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Clientes", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Método para buscar clientes por nombre
        public DataTable BuscarClientes(string filtro)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Clientes WHERE Nombre LIKE @filtro", conn);
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Método para agregar un nuevo cliente
        public void AgregarCliente(Cliente cliente)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Clientes (Nombre, Email, Telefono, Direccion) VALUES (@nombre, @correo, @telefono, @direccion)", conn);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@correo", cliente.Email);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para actualizar un cliente
        public void ActualizarCliente(Cliente cliente)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Clientes SET Nombre = @nombre, Email = @correo, Telefono = @telefono, Direccion = @direccion WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@correo", cliente.Email);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.ExecuteNonQuery();
            }
        }

        // Método para eliminar un cliente
        public void EliminarCliente(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Clientes WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Metodos para obtener proveedores
        public DataTable ObtenerProveedores()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Proveedores", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable BuscarProveedores(string filtro)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Proveedores WHERE Nombre LIKE @filtro", conn);
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Proveedores (Nombre, Contacto, Telefono, Email, Direccion) VALUES (@nombre, @contacto, @telefono, @correo, @direccion)", conn);
                cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@contacto", proveedor.Contacto);
                cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                cmd.Parameters.AddWithValue("@correo", proveedor.Email);
                cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Proveedores SET Nombre = @nombre, Contacto = @contacto, Telefono = @telefono, Email = @correo, Direccion = @direccion WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", proveedor.Id);
                cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@contacto", proveedor.Contacto);
                cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
                cmd.Parameters.AddWithValue("@correo", proveedor.Email);
                cmd.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProveedor(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Proveedores WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Metodos para obtener pedidos
        public DataTable ObtenerPedidos()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Pedidos", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable BuscarPedidos(string filtro)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Pedidos WHERE EstadoPedido LIKE @filtro", conn);
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AgregarPedido(Pedido pedido)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Pedidos (ProveedorId, FechaPedido, EstadoPedido, Total) VALUES (@proveedorId, @fechaPedido, @estadoPedido, @total)", conn);
                cmd.Parameters.AddWithValue("@proveedorId", pedido.ProveedorId);
                cmd.Parameters.AddWithValue("@fechaPedido", pedido.Fecha);
                cmd.Parameters.AddWithValue("@estadoPedido", pedido.EstadoPedido);
                cmd.Parameters.AddWithValue("@total", pedido.Total);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarPedido(Pedido pedido)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Pedidos SET ProveedorId = @proveedorId, FechaPedido = @fechaPedido, EstadoPedido = @estadoPedido, Total = @total WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", pedido.Id);
                cmd.Parameters.AddWithValue("@proveedorId", pedido.ProveedorId);
                cmd.Parameters.AddWithValue("@fechaPedido", pedido.Fecha);
                cmd.Parameters.AddWithValue("@estadoPedido", pedido.EstadoPedido);
                cmd.Parameters.AddWithValue("@total", pedido.Total);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPedido(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Pedidos WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Metodos para obtener venta
        public void AgregarVenta(Venta venta)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Ventas (ClienteId, Fecha, Total) VALUES (@clienteId, @fecha, @total)", conn);
                cmd.Parameters.AddWithValue("@clienteId", venta.ClienteId);
                cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@total", venta.Total);
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarVenta(Venta venta)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Ventas SET ClienteId = @clienteId, Fecha = @fecha, Total = @total WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", venta.Id);
                cmd.Parameters.AddWithValue("@clienteId", venta.ClienteId);
                cmd.Parameters.AddWithValue("@fecha", venta.Fecha);
                cmd.Parameters.AddWithValue("@total", venta.Total);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarVenta(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Ventas WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerVentas()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Ventas", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        // Metodos para obtener pagos
        public DataTable ObtenerPagos()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Pagos", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AgregarPago(Pago pago)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Pagos (VentaId, MetodoPagoId, Fecha, Monto) VALUES (@ventaId, @metodoPagoId, @fecha, @monto)", conn);
                cmd.Parameters.AddWithValue("@ventaId", pago.VentaId);
                cmd.Parameters.AddWithValue("@metodoPagoId", pago.MetodoPagoId);
                cmd.Parameters.AddWithValue("@fecha", pago.Fecha);
                cmd.Parameters.AddWithValue("@monto", pago.Total);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarPago(Pago pago)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Pagos SET VentaId = @ventaId, MetodoPagoId = @metodoPagoId, Fecha = @fecha, Monto = @monto WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", pago.Id);
                cmd.Parameters.AddWithValue("@ventaId", pago.VentaId);
                cmd.Parameters.AddWithValue("@metodoPagoId", pago.MetodoPagoId);
                cmd.Parameters.AddWithValue("@fecha", pago.Fecha);
                cmd.Parameters.AddWithValue("@monto", pago.Total);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarPago(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Pagos WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Método para obtener los métodos de pago utilizados en el formulario de pagos
        public DataTable ObtenerMetodosPagoParaPagos()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM MetodosPago WHERE Activo = 1", conn); // Solo activos para pagos
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable ObtenerMovimientosInventario()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM MovimientoInventario", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        
        public void AgregarMovimientoInventario(MovimientoInventario movimiento)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO MovimientoInventario (ProductoId, Cantidad, TipoMovimiento, Fecha, Motivo) VALUES (@productoId, @cantidad, @tipoMovimiento, @fecha, @motivo)", conn);
                cmd.Parameters.AddWithValue("@productoId", movimiento.ProductoId);
                cmd.Parameters.AddWithValue("@cantidad", movimiento.Cantidad);
                cmd.Parameters.AddWithValue("@tipoMovimiento", movimiento.TipoMovimiento);
                cmd.Parameters.AddWithValue("@fecha", movimiento.Fecha);
                cmd.Parameters.AddWithValue("@motivo", movimiento.Motivo);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarMovimientoInventario(MovimientoInventario movimiento)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE MovimientoInventario SET ProductoId = @productoId, Cantidad = @cantidad, TipoMovimiento = @tipoMovimiento, Fecha = @fecha, Motivo = @motivo WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", movimiento.Id);
                cmd.Parameters.AddWithValue("@productoId", movimiento.ProductoId);
                cmd.Parameters.AddWithValue("@cantidad", movimiento.Cantidad);
                cmd.Parameters.AddWithValue("@tipoMovimiento", movimiento.TipoMovimiento);
                cmd.Parameters.AddWithValue("@fecha", movimiento.Fecha);
                cmd.Parameters.AddWithValue("@motivo", movimiento.Motivo);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarMovimientoInventario(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM MovimientoInventario WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerMetodosPagoParaConfiguracion()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM MetodosPago", conn); // Todos los métodos de pago
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public void AgregarMetodoPago(MetodoPago metodoPago)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO MetodosPago (Metodo) VALUES (@metodo)", conn);
                cmd.Parameters.AddWithValue("@metodo", metodoPago.Metodo);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarMetodoPago(int id, string metodo)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE MetodosPago SET Metodo = @metodo WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@metodo", metodo);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarMetodoPago(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM MetodosPago WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Metodos para obtener Usuarios
        public DataTable ObtenerUsuarios()
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Usuarios", conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AgregarUsuario(Usuario usuario)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Usuarios (Username, Password) VALUES (@username, @password)", conn);
                cmd.Parameters.AddWithValue("@username", usuario.Username);
                cmd.Parameters.AddWithValue("@password", usuario.Password);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE Usuarios SET Username = @username, Password = @password WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@username", usuario.Username);
                cmd.Parameters.AddWithValue("@password", usuario.Password);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int id)
        {
            using (var conn = ObtenerConexion())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Usuarios WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


    }
}