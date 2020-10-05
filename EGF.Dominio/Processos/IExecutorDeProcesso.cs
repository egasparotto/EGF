using EGF.Dominio.Entidades;

namespace EGF.Processos.Base
{
    public interface IExecutorDeProcesso<T> where T : EntidadeDeProcesso
    {
        void Executar(T processo);
    }
}