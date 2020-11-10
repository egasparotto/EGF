using EGF.Dominio.Fabricas;
using EGF.Licenciamento.Core.Licencas.Entidades;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.EntityFrameworkCore;

namespace EGF.Dados.EFCore.Fabricas
{
    public abstract class FabricaDeConexao : IFabricaDeConexao
    {
        protected Licenca Licenca { get; private set; }

        protected FabricaDeConexao(IGerenciadorDeLicenca gerenciadorDeLicenca)
        {
            Licenca = gerenciadorDeLicenca.ObterLicenca();
        }

        public void DefinirLicenca(Licenca licenca)
        {
            Licenca = licenca;
        }

        public abstract DbContextOptions Fabricar();
    }
}
