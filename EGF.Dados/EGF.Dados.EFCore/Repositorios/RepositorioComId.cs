using EGF.Dados.EFCore.Contexto;
using EGF.Dados.EFCore.UnidadesDeTrabalho;
using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System.Linq;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioComId<TEntidade, TContexto> : RepositorioBase<TEntidade,TContexto>, IRepositorioComId<TEntidade>
        where TContexto : ContextoDaAplicacaoBase
        where TEntidade : EntidadeComId
    {
        protected RepositorioComId(UnidadeDeTrabalhoBase<TContexto> unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }

        public virtual TEntidade ObterPorId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();
        }
    }
}
