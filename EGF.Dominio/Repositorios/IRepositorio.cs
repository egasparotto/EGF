using EGF.Dominio.Entidades;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGF.Dominio.Repositorios
{
    public interface IRepositorio<TEntidade>
        where TEntidade : Entidade
    {
        public IEnumerable<TEntidade> Buscar();
        public IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa);
        public TEntidade Inserir(TEntidade entidade);
        public TEntidade Editar(TEntidade entidade);
        public void Remover(TEntidade entidade);
        public int NumeroDeRegistros();

        Task<IEnumerable<TEntidade>> BuscarAsync();
        Task<IEnumerable<TEntidade>> BuscarAsync(Func<TEntidade, bool> func);
        Task<TEntidade> EditarAsync(TEntidade entidade);
        Task<TEntidade> InserirAsync(TEntidade entidade);
        Task<int> NumeroDeRegistrosAsync();
        Task RemoverAsync(TEntidade entidade);
    }
}
