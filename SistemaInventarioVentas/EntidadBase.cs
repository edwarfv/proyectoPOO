namespace SistemaInventarioVentas
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }

        // Método abstracto que las clases hijas deberán implementar
        public abstract void MostrarInformacion();
    }
}
