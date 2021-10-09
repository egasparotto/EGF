using EGF.Licenciamento.Core.Licencas.Entidades;

namespace EGF.Licenciamento.Core.Licencas.Gerenciadores
{
    public interface IGerenciadorDeLicenca
    {
        Licenca ObterLicenca();
        string GerarHashDaLicenca(Licenca licenca);
        bool LicencaExiste();
        Licenca ObterLicencaDoHash(string hash);
    }
}
