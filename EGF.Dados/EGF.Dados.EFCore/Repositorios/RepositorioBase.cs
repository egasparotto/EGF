using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        public virtual IEnumerable<TEntidade> Buscar()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa)
        {
            throw new NotImplementedException();
        }

        public virtual TEntidade Editar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public virtual TEntidade Inserir(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public virtual int NumeroDeRegistros()
        {
            throw new NotImplementedException();
        }

        public virtual void Remover(TEntidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}
