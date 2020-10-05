using EGF.Dominio.Fabricas;
using EGF.Licenciamento.Core.Licencas.Entidades;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Processos.Fabricas
{
    public class FabricaDeConexaoDeProcesso : IFabricaDeConexao
    {
        private Licenca licenca;
        public void DefinirLicenca(Licenca licenca)
        {
            this.licenca = licenca;
        }

        public  DbContextOptions Fabricar()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(ConnectionString());
            var dbContext = new DbContext(builder.Options);
            return builder.Options;
        }

        private string ConnectionString()
        {;
            return $"Server={licenca.ServidorBanco};Database={licenca.NomeBanco};User Id={licenca.UsuarioBanco};Password={licenca.SenhaBanco};";
        }
    }
}
