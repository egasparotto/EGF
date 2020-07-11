using EGF.Dados.EFCore.Contextos;
using EGF.Dados.EFCore.UnidadesDeTrabalho;
using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System.Linq;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioComId<TEntidade, TContexto> : Repositorio<TEntidade,TContexto>, IRepositorioComId<TEntidade>
        where TContexto : Contexto
        where TEntidade : EntidadeComId
    {
        protected RepositorioComId(UnidadeDeTrabalho<TContexto> unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();
        }
    }
}
