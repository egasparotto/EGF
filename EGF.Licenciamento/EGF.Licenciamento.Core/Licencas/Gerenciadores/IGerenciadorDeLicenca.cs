﻿using EGF.Licenciamento.Core.Licencas.Entidades;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Licenciamento.Core.Licencas.Gerenciadores
{
    public interface IGerenciadorDeLicenca
    {
        Licenca ObterLicenca();
        void SalvarLicenca(Licenca licenca);
        string GerarHashDaLicenca(Licenca licenca);
        void AtivarLicenca(string hash);
        bool LicencaExiste();
        Licenca ObterLicencaDoHash(string hash);
    }
}
