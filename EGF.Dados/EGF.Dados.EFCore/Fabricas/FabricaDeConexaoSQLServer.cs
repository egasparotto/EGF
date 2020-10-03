using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dados.EFCore.Fabricas
{
    public class FabricaDeConexaoSQLServer : FabricaDeConexao
    {
        public FabricaDeConexaoSQLServer(IGerenciadorDeLicenca gerenciadorDeLicenca) : base(gerenciadorDeLicenca)
        {
        }

        public override DbContextOptions Fabricar()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(ConnectionString());
            var dbContext = new DbContext(builder.Options);
            return builder.Options;
        }

        private string ConnectionString()
        {
            var licenca = GerenciadorDeLicenca.ObterLicenca();
            return $"Server={licenca.ServidorBanco};Database={licenca.NomeBanco};User Id={licenca.UsuarioBanco};Password={licenca.SenhaBanco};";
        }

    }
}
