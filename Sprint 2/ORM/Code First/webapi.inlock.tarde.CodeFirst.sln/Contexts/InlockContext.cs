using Microsoft.EntityFrameworkCore;
using webapi.inlock.tarde.CodeFirst.sln.Domains;

namespace webapi.inlock.tarde.CodeFirst.sln.Contexts
{
    public class InlockContext : DbContext
    {
        public DbSet<TipoDeUsuarioDomain> TipoDeUsuarios { get; set; }
        public DbSet<UsuarioDomain> Usuario { get; set; }
        public DbSet<EstudioDomain> Estudio { get; set; }
        public DbSet<JogoDomain> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlServer("Server=NOTE06-S15; Database=Inlock_games_CodeFirst_Miguel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true;");
            base.OnConfiguring(optionsBuider);
        }

    }
}
