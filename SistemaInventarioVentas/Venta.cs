using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    internal class Venta : Transaccion
    {
        public int ClienteId { get; set; } // ID del cliente asociado a la venta

        // Constructor que llama al constructor base de Transaccion
        public Venta(int clienteId, DateTime fechaVenta, decimal total)
            : base(fechaVenta, total)
        {
            ClienteId = clienteId;
        }
    }
}