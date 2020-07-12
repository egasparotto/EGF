using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using System;
using System.Collections.Generic;
using System.Linq;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class Repositorio<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : Entidade
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }

        protected Repositorio(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public virtual IEnumerable<TEntidade> Buscar()
        {
            return UnidadeDeTrabalho.Contexto.Set<TEntidade>();
        }

        public virtual IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa)
        {
            return UnidadeDeTrabalho.Contexto.Set<TEntidade>().Where(pesquisa);
        }

        public virtual TEntidade Editar(TEntidade entidade)
        {
            return UnidadeDeTrabalho.Contexto.Update(entidade).Entity;
        }

        public virtual TEntidade Inserir(TEntidade entidade)
        {
            return UnidadeDeTrabalho.Contexto.Add(entidade).Entity;
        }

        public virtual int NumeroDeRegistros()
        {
            return UnidadeDeTrabalho.Contexto.Set<TEntidade>().Count();
        }

        public virtual void Remover(TEntidade entidade)
        {
            UnidadeDeTrabalho.Contexto.Remove(entidade);
        }
    }
}
