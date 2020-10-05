using EGF.Dominio.Fabricas;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dados.EFCore.Fabricas
{
    public abstract class FabricaDeConexao : IFabricaDeConexao
    {
        protected IGerenciadorDeLicenca GerenciadorDeLicenca { get; }

        protected FabricaDeConexao(IGerenciadorDeLicenca gerenciadorDeLicenca)
        {
            GerenciadorDeLicenca = gerenciadorDeLicenca;
        }

        public abstract DbContextOptions Fabricar();
    }
}
