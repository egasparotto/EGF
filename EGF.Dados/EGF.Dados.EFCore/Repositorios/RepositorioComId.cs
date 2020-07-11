using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioComId<TEntidade> : RepositorioBase<TEntidade>, IRepositorioComId<TEntidade>
        where TEntidade:EntidadeComId
    {
        public virtual TEntidade ObterPorId(int id)
        {
            return Buscar(x => x.Id == id).FirstOrDefault();
        }
    }
}
