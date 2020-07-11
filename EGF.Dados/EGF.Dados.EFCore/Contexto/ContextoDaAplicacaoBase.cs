using Microsoft.EntityFrameworkCore;

namespace EGF.Dados.EFCore.Contexto
{
    public abstract class ContextoDaAplicacaoBase : DbContext
    {
        public ContextoDaAplicacaoBase(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapearBancoDeDados(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public abstract void MapearBancoDeDados(ModelBuilder modelBuilder);
    }
}
