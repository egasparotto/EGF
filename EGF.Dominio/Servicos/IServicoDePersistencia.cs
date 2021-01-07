using EGF.Dominio.Entidades;

using System;
using System.Collections.Generic;

namespace EGF.Dominio.Servicos
{
    public interface IServicoDePersistencia<TEntidade>
        where TEntidade : EntidadeComId
    {
        IEnumerable<TEntidade> Buscar();
        IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa);
        TEntidade Inserir(TEntidade entidade);
        TEntidade Editar(TEntidade entidade);
        TEntidade ObterPorID(int id);
        void Remover(TEntidade entidade);
    }
}
