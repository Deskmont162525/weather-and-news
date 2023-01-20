using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class ConexionSqlServer:DbContext
    {
        public ConexionSqlServer(DbContextOptions<ConexionSqlServer> options) : base(options) 
        { 
            //
        }

        public DbSet<Usuario> USUARIO { get; set; }
    }
}
