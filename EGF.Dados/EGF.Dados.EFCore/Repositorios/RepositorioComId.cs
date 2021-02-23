using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using System;
using System.Linq;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioComId<TID, TEntidade> : Repositorio<TEntidade>, IRepositorioComId<TID, TEntidade>
        where TID : IComparable
        where TEntidade : EntidadeComId<TID>
    {
        protected RepositorioComId(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }

        public virtual TEntidade ObterPorId(TID id)
        {
            return Buscar(x => x.Id.CompareTo(id) == 0).FirstOrDefault();
        }
    }
}
