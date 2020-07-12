
using EGF.Dominio.Contextos;

using Microsoft.EntityFrameworkCore;

namespace EGF.Dados.EFCore.Contextos
{
    public abstract class Contexto : DbContext, IContexto
    {
        public Contexto(DbContextOptions options) : base(options)
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
