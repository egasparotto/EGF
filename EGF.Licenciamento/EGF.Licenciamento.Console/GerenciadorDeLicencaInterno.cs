using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using System;

namespace EGF.Licenciamento.Console
{
    public class GerenciadorDeLicencaInterno : GerenciadorDeLicencaArquivo
    {
        protected override string LocalDoArquivo()
        {
            throw new NotImplementedException();
        }

        protected override string NomeDaLicenca()
        {
            throw new NotImplementedException();
        }
    }
}
