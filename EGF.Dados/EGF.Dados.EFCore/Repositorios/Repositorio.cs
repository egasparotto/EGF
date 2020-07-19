using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGF.Dados.EFCore.Repositorios
{
    public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade>
        where TEntidade : Entidade
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }

        protected Repositorio(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public virtual IQueryable<TEntidade> Buscar()
        {
            return UnidadeDeTrabalho.Contexto.Set<TEntidade>();
        }

        public virtual IQueryable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa)
        {
            return Buscar().Where(pesquisa).AsQueryable();
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

        public virtual async Task<IQueryable<TEntidade>> BuscarAsync()
        {
            return await Task.FromResult(Buscar());
        }

        public async Task<IQueryable<TEntidade>> BuscarAsync(Func<TEntidade, bool> func)
        {
            return (await BuscarAsync()).Where(func).AsQueryable();
        }

        public virtual async Task<TEntidade> EditarAsync(TEntidade entidade)
        {
            return await Task.FromResult(UnidadeDeTrabalho.Contexto.Set<TEntidade>().Update(entidade).Entity);
        }

        public virtual async Task<TEntidade> InserirAsync(TEntidade entidade)
        {
            return await Task.FromResult(UnidadeDeTrabalho.Contexto.Add(entidade).Entity);
        }

        public virtual async Task<int> NumeroDeRegistrosAsync()
        {
            return await Task.FromResult(UnidadeDeTrabalho.Contexto.Set<TEntidade>().Count());
        }

        public virtual async Task RemoverAsync(TEntidade entidade)
        {
            await Task.FromResult(UnidadeDeTrabalho.Contexto.Remove(entidade));
        }

    }
}
