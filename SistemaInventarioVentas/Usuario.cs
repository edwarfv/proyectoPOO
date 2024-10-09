using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    internal class Usuario
    {
        public int Id { get; set; } // ID del usuario
        public string Username { get; set; } // Nombre de usuario
        public string Password { get; set; } // Contraseña del usuario

        public Usuario() { }
        // Constructor
        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
