using EGF.Dados.EFCore.Fabricas;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.EntityFrameworkCore;

namespace EGF.Dados.EFCore.SQLServer.Fabricas
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
            OpcoesAdicionais(builder).UseSqlServer(ConnectionString(), x =>
            {
                if (!string.IsNullOrEmpty(_assemblyMigracao))
                {
                    x.MigrationsAssembly(_assemblyMigracao);
                }
            });
            return builder.Options;
        }

        private string ConnectionString()
        {
            return $"Server={Licenca.ServidorBanco};Database={Licenca.NomeBanco};User Id={Licenca.UsuarioBanco};Password={Licenca.SenhaBanco};";
        }

    }
}
