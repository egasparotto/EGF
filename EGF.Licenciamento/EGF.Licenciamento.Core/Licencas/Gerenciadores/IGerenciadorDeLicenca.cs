using EGF.Licenciamento.Core.Licencas.Entidades;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Licenciamento.Core.Licencas.Gerenciadores
{
    public interface IGerenciadorDeLicenca
    {
        Licenca ObterLicenca();
        void SalvarLicenca(Licenca licenca);
    }
}
