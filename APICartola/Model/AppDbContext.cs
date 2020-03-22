

using Microsoft.EntityFrameworkCore;
namespace APICartola.Model
{
    public class CartolaContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Acao> Acao { get; set; }
        public DbSet<Carteira> Carteira { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Cotacao> Cotacao { get; set; }
        public DbSet<UsuarioGrupo> UsuarioGrupo { get; set; }

        public CartolaContext(DbContextOptions<CartolaContext> options) :
            base(options)
        {
        }
    }
}