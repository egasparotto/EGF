using EGF.Dominio.Entidades;
using EGF.Dominio.UnidadesDeTrabalho;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Processos.Base
{
    public abstract class ExecutorDeProcesso<T> : IExecutorDeProcesso<T> where T : EntidadeDeProcesso
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }

        public ExecutorDeProcesso(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public abstract void Executar(T processo);
    }
}
