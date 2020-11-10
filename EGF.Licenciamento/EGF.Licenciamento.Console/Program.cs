using EGF.Licenciamento.Console;
using EGF.Licenciamento.Core.Licencas.Entidades;

using System;
using System.Globalization;


Console.WriteLine("Gerador de Licenças EGF");
Console.WriteLine($"Início da Validade[{DateTime.Today}]:");
var strInicioValidade = Console.ReadLine();
var inicioValidade = DateTime.Today;
if (!string.IsNullOrEmpty(strInicioValidade))
{
    inicioValidade = DateTime.ParseExact(strInicioValidade, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
}


Console.WriteLine($"Término da Validade[{DateTime.Today.AddYears(1)}]:");
var strTerminoValidade = Console.ReadLine();
var terminoValidade = DateTime.Today.AddYears(1);
if (!string.IsNullOrEmpty(strTerminoValidade))
{
    terminoValidade = DateTime.ParseExact(strTerminoValidade, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
}

Console.WriteLine($"Servidor de Banco de Dados:");
var servidorBanco = Console.ReadLine();

Console.WriteLine($"Nome do Banco de Dados:");
var nomeBanco = Console.ReadLine();

Console.WriteLine($"Usuario do Banco de Dados:");
var usuarioBanco = Console.ReadLine();

Console.WriteLine($"Senha do Banco de Dados:");
var senhaBanco = Console.ReadLine();

Console.WriteLine($"Servidor do Kafka:");
var servidorKafka = Console.ReadLine();

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
Console.WriteLine();
Console.WriteLine("Hash Gerado:");
Console.WriteLine();
var hash = new GerenciadorDeLicencaInterno().GerarHashDaLicenca(licenca);

Console.WriteLine(hash);

Console.ReadKey();
