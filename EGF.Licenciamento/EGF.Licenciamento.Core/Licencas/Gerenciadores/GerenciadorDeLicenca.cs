
using EGF.Licenciamento.Core.Licencas.Entidades;
using EGF.ServicosDeAplicacao.Utils.Criptografia;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;



namespace EGF.Licenciamento.Core.Licencas.Gerenciadores
{
    public abstract class GerenciadorDeLicenca : IGerenciadorDeLicenca
    {
        private readonly IDictionary<string, Licenca> _licencas;
        private readonly string _hash = "c60550e57da69b59e21134418a6c1e9d";

        protected GerenciadorDeLicenca()
        {
            _licencas = new Dictionary<string, Licenca>();
        }

        public Licenca ObterLicenca()
        {
            if (_licencas.TryGetValue(NomeDaLicenca(), out Licenca licenca))
            {
                return licenca;
            }
            else
            {
                try
                {
                    var localArquivo = LocalDoArquivo();
                    if (localArquivo != null)
                    {
                        var conteudoArquivo = CriptografiaAES.Descriptografa(_hash,File.ReadAllText(localArquivo));
                        licenca = JsonSerializer.Deserialize<Licenca>(conteudoArquivo);
                        _licencas.Add(NomeDaLicenca(), licenca);
                        return licenca;
                    }
                    throw new Exception("Erro ao localizar licença.");
                }
                catch
                {
                    throw new Exception("Erro ao localizar licença.");
                }
            }

        }


        public void SalvarLicenca(Licenca licenca)
        {
            var localArquivo = LocalDoArquivo();
            var conteudoArquivo = CriptografiaAES.Criptografa(_hash,JsonSerializer.Serialize(licenca));
            File.WriteAllText(localArquivo, conteudoArquivo);
        }

        protected abstract string LocalDoArquivo();
        protected abstract string NomeDaLicenca();
    }
}
