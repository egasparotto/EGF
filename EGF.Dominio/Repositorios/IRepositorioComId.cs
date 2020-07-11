using EGF.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dominio.Repositorios
{
    public interface IRepositorioComId<TEntidade>: IRepositorioBase<TEntidade>
        where TEntidade:EntidadeComId
    {
        public TEntidade ObterPorId(int id);
    }
}
