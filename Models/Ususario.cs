using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? Nombres { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Estado { get; set; }
    }
}
