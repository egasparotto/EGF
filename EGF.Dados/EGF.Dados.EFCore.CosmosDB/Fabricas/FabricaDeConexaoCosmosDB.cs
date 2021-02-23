using EGF.Dados.EFCore.Fabricas;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGF.Dados.EFCore.CosmosDB.Fabricas
{
    public class FabricaDeConexaoCosmosDB : FabricaDeConexao
    {
        public FabricaDeConexaoCosmosDB(IGerenciadorDeLicenca gerenciadorDeLicenca) : base(gerenciadorDeLicenca)
        {
        }

        public override DbContextOptions Fabricar()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseCosmos(Licenca.ServidorBanco, Licenca.NomeBanco);
            return builder.Options;
        }
    }
}
