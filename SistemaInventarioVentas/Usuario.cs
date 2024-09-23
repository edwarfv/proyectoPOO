using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Usuario() { }

        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
