using EGF.Dominio.Entidades;

using System.Threading.Tasks;

namespace EGF.Dominio.Servicos
{
    public interface IServicoDeProcesso<in T> where T : EntidadeDeProcesso
    {
        Task IncluirProcesso(T processo);
    }
}