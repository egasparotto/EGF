using EGF.Dominio.Contextos;

using System;

namespace EGF.Dominio.UnidadesDeTrabalho
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        IContexto Contexto { get; }
        void Commit();
    }
}
