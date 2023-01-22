using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public string? UsuarioIdFk { get; set; }        
        public string? City { get; set; }
        public string? Info { get; set; }
        public DateTime? FechaVista { get; set; }
    }
}
