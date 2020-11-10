using Confluent.Kafka;

using EGF.Dominio.Entidades;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using System.Text.Json;
using System.Threading.Tasks;

namespace EGF.Dominio.Servicos
{
    public class ServicoDeProcesso<T> : IServicoDeProcesso<T> where T : EntidadeDeProcesso
    {
        private readonly IGerenciadorDeLicenca _gerenciadorDeLicenca;

        public ServicoDeProcesso(IGerenciadorDeLicenca gerenciadorDeLicenca)
        {
            _gerenciadorDeLicenca = gerenciadorDeLicenca;
        }

        public virtual async Task IncluirProcesso(T processo)
        {
            var licenca = _gerenciadorDeLicenca.ObterLicenca();
            processo.Licenca = _gerenciadorDeLicenca.GerarHashDaLicenca(licenca);
            processo.Tipo = typeof(T).FullName;
            processo.Assembly = typeof(T).Assembly.FullName;

            var processoSerializado = JsonSerializer.Serialize<T>(processo);

            var servidor = licenca.ServidorKafka;
            var topic = "EGF.Processos";

            var config = new ProducerConfig
            {
                BootstrapServers = servidor
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var retorno = await producer.ProduceAsync(topic, new Message<Null, string> { Value = processoSerializado });
        }
    }
}
