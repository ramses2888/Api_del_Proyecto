namespace VisiCartAPI.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioCatalogo { get; set; }
        public float PesoEsperado { get; set; }
        public int IdCategoria { get; set; }
        public string? NombreCat { get; set; }
    }
}