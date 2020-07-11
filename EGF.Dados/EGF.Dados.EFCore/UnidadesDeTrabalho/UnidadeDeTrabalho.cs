using EGF.Dados.EFCore.Contextos;

using System;

namespace EGF.Dados.EFCore.UnidadesDeTrabalho
{
    public class UnidadeDeTrabalho<TContexto> : IDisposable
        where TContexto: Contexto
    {
        public TContexto Contexto { get; }
        public UnidadeDeTrabalho(TContexto contexto)
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
