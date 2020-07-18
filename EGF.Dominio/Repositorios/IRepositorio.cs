using EGF.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGF.Dominio.Repositorios
{
    public interface IRepositorio<TEntidade>
        where TEntidade : Entidade
    {
        public IQueryable<TEntidade> Buscar();
        public IQueryable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa);
        public TEntidade Inserir(TEntidade entidade);
        public TEntidade Editar(TEntidade entidade);
        public void Remover(TEntidade entidade);
        public int NumeroDeRegistros();

        Task<IQueryable<TEntidade>> BuscarAsync();
        Task<IQueryable<TEntidade>> BuscarAsync(Func<TEntidade, bool> func);
        Task<TEntidade> EditarAsync(TEntidade entidade);
        Task<TEntidade> InserirAsync(TEntidade entidade);
        Task<int> NumeroDeRegistrosAsync();
        Task RemoverAsync(TEntidade entidade);
    }
}
