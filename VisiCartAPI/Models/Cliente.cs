namespace VisiCartAPI.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Calle { get; set; }
        public string? Ciudad { get; set; }
    }
}