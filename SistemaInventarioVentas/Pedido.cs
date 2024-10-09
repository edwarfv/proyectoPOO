using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    internal class Pedido : Transaccion
    {
        public int ProveedorId { get; set; }    // ID del proveedor asociado al pedido
        public string EstadoPedido { get; set; } // Estado del pedido

        // Constructor que llama al constructor base de Transaccion
        public Pedido(int proveedorId, DateTime fechaPedido, string estadoPedido, decimal total)
            : base(fechaPedido, total)
        {
            ProveedorId = proveedorId;
            EstadoPedido = estadoPedido;
        }
    }
}