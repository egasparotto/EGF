using EGF.Dominio.Entidades;

namespace EGF.Dominio.Repositorios
{
    public interface IRepositorioComId<TEntidade> : IRepositorio<TEntidade>
        where TEntidade : EntidadeComId
    {
        public TEntidade ObterPorId(int id);
    }
}
