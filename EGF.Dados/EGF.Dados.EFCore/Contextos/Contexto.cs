using EGF.Dominio.Contextos;
using EGF.Dominio.Fabricas;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EGF.Dados.EFCore.Contextos
{
    public abstract class Contexto : DbContext, IContexto
    {
        public Contexto(IFabricaDeConexao fabrica) : base(fabrica.Fabricar())
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapearBancoDeDados(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public abstract void MapearBancoDeDados(ModelBuilder modelBuilder);

        public virtual T ObterAntesDaAlteracao<T>(T entidade) 
            where T : class
        {
            var nomesChaves = Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name);
            var valoresChaves = typeof(T).GetProperties().Where(x => nomesChaves.Contains(x.Name)).Select(x => x.GetValue(entidade)).ToArray();

            DbSet<T> dbSet = Set<T>();
            T entidadeAntesDaAlteracao = dbSet.Find(valoresChaves);
            Entry(entidadeAntesDaAlteracao).State = EntityState.Detached;
            return entidadeAntesDaAlteracao;
        }
    }
}
