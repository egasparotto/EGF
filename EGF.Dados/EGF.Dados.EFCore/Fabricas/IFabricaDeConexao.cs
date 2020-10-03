using Microsoft.EntityFrameworkCore;

namespace EGF.Dados.EFCore.Fabricas
{
    public interface IFabricaDeConexao
    {
        DbContextOptions Fabricar();
    }
}