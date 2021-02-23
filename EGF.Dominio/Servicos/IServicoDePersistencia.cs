using EGF.Dominio.Entidades;

using System;
using System.Collections.Generic;

namespace EGF.Dominio.Servicos
{
    public interface IServicoDePersistencia<TID,TEntidade>
        where TID : IComparable
        where TEntidade : EntidadeComId<TID>
    {
        IEnumerable<TEntidade> Buscar();
        IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa);
        TEntidade Inserir(TEntidade entidade);
        TEntidade Editar(TEntidade entidade);
        TEntidade ObterPorID(TID id);
        void Remover(TEntidade entidade);
    }
}
