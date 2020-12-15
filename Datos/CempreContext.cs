using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class CempreContext : DbContext
    {
        public CempreContext(DbContextOptions options) : base(options){ }
    
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<HojaDeVida> HojasDeVida {get; set;}
    }
}