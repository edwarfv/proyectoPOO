using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    public class Cliente : Persona
    {
        public Cliente(string nombre, string telefono, string email, string direccion)
            : base(nombre, telefono, email, direccion)
        {
        }

        // Implementación del método abstracto de Persona
        public override string ObtenerInformacion()
        {
            return $"Cliente: {Nombre}, Teléfono: {Telefono}, Email: {Email}, Dirección: {Direccion}";
        }
    }
}