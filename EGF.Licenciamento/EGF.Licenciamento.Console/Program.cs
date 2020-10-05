using EGF.Licenciamento.Core.Licencas.Entidades;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using System;
using System.Globalization;

namespace EGF.Licenciamento.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Gerador de Licenças EGF");
            System.Console.WriteLine($"Início da Validade[{DateTime.Today}]:");
            var strInicioValidade = System.Console.ReadLine();
            var inicioValidade = DateTime.Today;
            if (!string.IsNullOrEmpty(strInicioValidade))
            {
                inicioValidade = DateTime.ParseExact(strInicioValidade, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
            }


            System.Console.WriteLine($"Término da Validade[{DateTime.Today.AddYears(1)}]:");
            var strTerminoValidade = System.Console.ReadLine();
            var terminoValidade = DateTime.Today.AddYears(1);
            if (!string.IsNullOrEmpty(strTerminoValidade))
            {
                terminoValidade = DateTime.ParseExact(strTerminoValidade, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
            }

            System.Console.WriteLine($"Servidor de Banco de Dados:");
            var servidorBanco = System.Console.ReadLine();

            System.Console.WriteLine($"Nome do Banco de Dados:");
            var nomeBanco = System.Console.ReadLine();

            System.Console.WriteLine($"Usuario do Banco de Dados:");
            var usuarioBanco = System.Console.ReadLine();

            System.Console.WriteLine($"Senha do Banco de Dados:");
            var senhaBanco = System.Console.ReadLine();

            System.Console.WriteLine($"Servidor do Kafka:");
            var servidorKafka = System.Console.ReadLine();

            var licenca = new Licenca()
            {
                DataInicio = inicioValidade,
                DataTermino = terminoValidade,
                NomeBanco = nomeBanco,
                ServidorBanco = servidorBanco,
                UsuarioBanco = usuarioBanco,
                SenhaBanco = senhaBanco,
                ServidorKafka = servidorKafka
            };
            System.Console.WriteLine();
            System.Console.WriteLine("Hash Gerado:");
            System.Console.WriteLine();
            var hash = new GerenciadorDeLicencaInterno().GerarHashDaLicenca(licenca);

            System.Console.WriteLine(hash);

            System.Console.ReadKey();
        }


        private class GerenciadorDeLicencaInterno : GerenciadorDeLicenca
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
}
