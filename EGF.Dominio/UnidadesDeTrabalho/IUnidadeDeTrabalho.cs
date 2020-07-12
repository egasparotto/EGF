using EGF.Dominio.Contextos;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dominio.UnidadesDeTrabalho
{
    public interface IUnidadeDeTrabalho: IDisposable
    {
        IContexto Contexto { get; }
        void Commit();
    }
}
