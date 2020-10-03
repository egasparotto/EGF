using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dados.EFCore.Fabricas
{
    public class FabricaDeConexaoSQLServer : FabricaDeConexao
    {
        private readonly string _assemblyMigracao;
        public FabricaDeConexaoSQLServer(IGerenciadorDeLicenca gerenciadorDeLicenca, string assemblyMigracao) : base(gerenciadorDeLicenca)
        {
            _assemblyMigracao = assemblyMigracao;
        }

        public override DbContextOptions Fabricar()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(ConnectionString(), x => x.MigrationsAssembly(_assemblyMigracao));
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
