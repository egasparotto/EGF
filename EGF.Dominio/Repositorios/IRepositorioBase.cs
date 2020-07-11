using EGF.Dominio.Entidades;

using System;
using System.Collections.Generic;

namespace EGF.Dominio.Repositorios
{
    public interface IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        public IEnumerable<TEntidade> Buscar();
        public IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa);
        public TEntidade Inserir(TEntidade entidade);
        public TEntidade Editar(TEntidade entidade);
        public void Remover(TEntidade entidade);
        public int NumeroDeRegistros();
    }
}
