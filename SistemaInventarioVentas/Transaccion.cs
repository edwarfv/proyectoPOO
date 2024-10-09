using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    public abstract class Transaccion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        // Constructor común para todas las transacciones
        protected Transaccion(DateTime fecha, decimal total)
        {
            Fecha = fecha;
            Total = total;
        }
    }
}