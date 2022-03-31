using Confluent.Kafka;

using EGF.Dominio.Entidades;
using EGF.Dominio.Fabricas;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;
using EGF.Processos.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EGF.Processos
{
    public class ReceptorDeProcessos : IHostedService
    {
        private readonly IConfiguration _configuration;
        private readonly IDictionary<string, Type> _executores;
        private readonly IServiceProvider _services;

        public ReceptorDeProcessos(IConfiguration configuration, IGerenciadorDeExecutoresDeProcessos gerenciadorDeExecutores, IServiceProvider services)
        {
            _configuration = configuration;
            _executores = gerenciadorDeExecutores.ObterExecutores();
            _services = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            string servidorKafka = _configuration.GetSection("Kafka").Value;
            var conf = new ConsumerConfig
            {
                GroupId = "Consumidor-EGF.Processos",
                BootstrapServers = servidorKafka,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                c.Subscribe("EGF.Processos");
                var cts = new CancellationTokenSource();

                try
                {
                    while (true)
                    {
                        var message = c.Consume(cts.Token);

                        try
                        {
                            var processo = JsonSerializer.Deserialize<EntidadeDeProcesso>(message.Message.Value);
                            var tipo = processo.Tipo;
                            if (_executores.TryGetValue(tipo, out Type tipoExecutor))
                            {
                                using var escopo = _services.CreateScope();
                                var gerenciadorDeLicenca = escopo.ServiceProvider.GetService<IGerenciadorDeLicenca>();
                                var licenca = gerenciadorDeLicenca.ObterLicencaDoHash(processo.Licenca);
                                var fabricaDeConexao = escopo.ServiceProvider.GetService<IFabricaDeConexao>();
                                fabricaDeConexao.DefinirLicenca(licenca);
                                var executor = escopo.ServiceProvider.GetRequiredService(tipoExecutor);
                                var assembly = Assembly.Load(processo.Assembly);
                                var type = assembly.GetType(tipo);
                                var processoConvertido = JsonSerializer.Deserialize(message.Message.Value, type);
                                tipoExecutor.GetMethod("Executar").Invoke(executor, new object[] { processoConvertido });
                                c.Commit(message);
                            }
                        }
                        catch
                        {
                            c.Commit(message);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    c.Close();
                }
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
