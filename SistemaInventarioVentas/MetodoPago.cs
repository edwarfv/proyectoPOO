using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    internal class MetodoPago
    {
        public int Id { get; set; }      // ID del método de pago
        public string Metodo { get; set; } // Nombre del método de pago (Ej. Tarjeta, Efectivo)

        public MetodoPago(string metodo)
        {
            Metodo = metodo;
        }
        // Constructor para casos donde ya se tiene el Id (por ejemplo, al actualizar)
        public MetodoPago(int id, string metodo)
        {
            Id = id;
            Metodo = metodo;
        }
    }
}