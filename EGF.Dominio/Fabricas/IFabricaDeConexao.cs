
using EGF.Licenciamento.Core.Licencas.Entidades;

using Microsoft.EntityFrameworkCore;

namespace EGF.Dominio.Fabricas
{
    public interface IFabricaDeConexao
    {
        DbContextOptions Fabricar();
        void DefinirLicenca(Licenca licenca);
    }
}