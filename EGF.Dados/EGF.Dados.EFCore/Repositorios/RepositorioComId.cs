using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using System.Linq;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioComId<TEntidade> : Repositorio<TEntidade>, IRepositorioComId<TEntidade>
        where TEntidade : EntidadeComId
    {
        protected RepositorioComId(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();
        }
    }
}
