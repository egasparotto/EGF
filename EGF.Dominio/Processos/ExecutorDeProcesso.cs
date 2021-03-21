using EGF.Dominio.Entidades;
using EGF.Dominio.UnidadesDeTrabalho;

namespace EGF.Processos.Base
{
    public abstract class ExecutorDeProcesso<T> : IExecutorDeProcesso<T> where T : EntidadeDeProcesso
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }

        protected ExecutorDeProcesso(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public abstract void Executar(T processo);
    }
}
