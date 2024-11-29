using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioVentas
{
    internal class Producto : EntidadBase
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int CategoriaId { get; set; }  // ID de la categoría a la que pertenece el producto

        // Constructor vacío
        public Producto()
        {
            CategoriaId = 0;  // Asignar un valor por defecto (opcional)
        }

        // Constructor que incluye todos los campos
        public Producto(string nombre, decimal precio, int cantidad, int categoriaId)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            CategoriaId = categoriaId;  // Asignar la categoría al constructor
        }

        // Implementación del método abstracto
        public override void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}, Precio: {Precio}, Cantidad: {Cantidad}, Categoría: {CategoriaId}");
        }
    }
}

