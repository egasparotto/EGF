using EGF.Dominio.Entidades;

namespace EGF.Processos.Base
{
    public interface IExecutorDeProcesso<in T> where T : EntidadeDeProcesso
    {
        void Executar(T processo);
    }
}