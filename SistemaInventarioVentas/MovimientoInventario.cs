using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{

    internal class MovimientoInventario
    {
        public int Id { get; set; } // Asegúrate de que el campo Id esté presente
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }

        // Constructor
        public MovimientoInventario(int id, int productoId, int cantidad, string tipoMovimiento, DateTime fecha, string motivo)
        {
            Id = id; // Inicializar el Id
            ProductoId = productoId;
            Cantidad = cantidad;
            TipoMovimiento = tipoMovimiento;
            Fecha = fecha;
            Motivo = motivo;
        }

    }
}
