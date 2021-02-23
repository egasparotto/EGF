using EGF.Dominio.Entidades;

using System;

namespace EGF.Dominio.Repositorios
{
    public interface IRepositorioComId<TID,TEntidade> : IRepositorio<TEntidade>
        where TID : IComparable
        where TEntidade : EntidadeComId<TID>
    {
        public TEntidade ObterPorId(TID id);
    }
}
