using EGF.Dados.EFCore.Contextos;
using EGF.Dominio.Contextos;
using EGF.Dominio.UnidadesDeTrabalho;

using System;

namespace EGF.Dados.EFCore.UnidadesDeTrabalho
{
    public class UnidadeDeTrabalho : IDisposable, IUnidadeDeTrabalho
    {
        public IContexto Contexto { get; }
        public UnidadeDeTrabalho(IContexto contexto)
        {
            Contexto = contexto;
        }

        public void Commit()
        {
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}
