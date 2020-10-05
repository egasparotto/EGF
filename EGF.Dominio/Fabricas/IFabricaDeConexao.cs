
using Microsoft.EntityFrameworkCore;

namespace EGF.Dominio.Fabricas
{
    public interface IFabricaDeConexao
    {
        DbContextOptions Fabricar();
    }
}