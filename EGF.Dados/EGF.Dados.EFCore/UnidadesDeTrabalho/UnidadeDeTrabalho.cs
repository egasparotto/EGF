using EGF.Dados.EFCore.Contexto;

using System;

namespace EGF.Dados.EFCore.UnidadesDeTrabalho
{
    public class UnidadeDeTrabalhoBase<TContexto> : IDisposable
        where TContexto: ContextoDaAplicacaoBase
    {
        public TContexto Contexto { get; }
        public UnidadeDeTrabalhoBase(TContexto contexto)
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
