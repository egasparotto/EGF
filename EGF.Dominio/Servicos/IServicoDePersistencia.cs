using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dominio.Servicos
{
    public interface IServicoDePersistencia<TEntidade>
        where TEntidade:Entidade
    {
        IEnumerable<TEntidade> Buscar();
        IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa);
        TEntidade Inserir(TEntidade entidade);
        TEntidade Editar(TEntidade entidade);
        void Remover(TEntidade entidade);
    }
}
