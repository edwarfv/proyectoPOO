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
    }
}