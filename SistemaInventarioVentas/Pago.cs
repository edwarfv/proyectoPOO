using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    internal class Pago : Transaccion
    {
        public int VentaId { get; set; }      // ID de la venta relacionada con el pago
        public int MetodoPagoId { get; set; } // ID del método de pago usado en la transacción

        // Constructor que llama al constructor base de Transaccion
        public Pago(int ventaId, int metodoPagoId, DateTime fecha, decimal monto)
            : base(fecha, monto)
        {
            VentaId = ventaId;
            MetodoPagoId = metodoPagoId;
        }
    }
}