using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        // Método abstracto para obtener información detallada
        public abstract string ObtenerInformacion();

        // Constructor común para todas las clases derivadas
        protected Persona(string nombre, string telefono, string email, string direccion)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }
    }
}