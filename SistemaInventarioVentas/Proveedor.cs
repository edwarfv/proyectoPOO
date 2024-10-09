using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    public class Proveedor : Persona
    {
        public string Contacto { get; set; }

        // Constructor que llama al constructor base de Persona
        public Proveedor(string nombre, string contacto, string telefono, string email, string direccion)
            : base(nombre, telefono, email, direccion)
        {
            Contacto = contacto;
        }

        // Implementación del método abstracto de Persona
        public override string ObtenerInformacion()
        {
            return $"Proveedor: {Nombre}, Contacto: {Contacto}, Teléfono: {Telefono}, Email: {Email}";
        }
    }
}