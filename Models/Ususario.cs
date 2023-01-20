using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? DocumentoIdentidad { get; set; }
        public string? Nombres { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Ciudad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
