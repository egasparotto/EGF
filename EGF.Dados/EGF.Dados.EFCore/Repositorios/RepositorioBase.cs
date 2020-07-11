using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        public IEnumerable<TEntidade> Buscar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa)
        {
            throw new NotImplementedException();
        }

        public TEntidade Editar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public TEntidade Inserir(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public int NumeroDeRegistros()
        {
            throw new NotImplementedException();
        }

        public void Remover(TEntidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}
