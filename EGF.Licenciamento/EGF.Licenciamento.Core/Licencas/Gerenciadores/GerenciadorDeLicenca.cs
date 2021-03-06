﻿
using EGF.Excecoes;
using EGF.Licenciamento.Core.Licencas.Entidades;
using EGF.ServicosDeAplicacao.Utils.Criptografia;

using System;
using System.Collections.Generic;
using System.IO;
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
            var nomeLicenca = NomeDaLicenca();
            if (nomeLicenca == null)
            {
                return new Licenca();
            }
            if (_licencas.TryGetValue(nomeLicenca, out Licenca licenca))
            {
                return licenca;
            }
            else
            {
                try
                {
                    var localArquivo = LocalDoArquivo();
                    if (!File.Exists(localArquivo))
                    {
                        throw new FileNotFoundException("Erro ao localizar o arquivo: " + localArquivo);
                    }
                    var conteudoArquivo = CriptografiaAES.Descriptografa(_hash, File.ReadAllText(localArquivo));
                    licenca = JsonSerializer.Deserialize<Licenca>(conteudoArquivo);
                    _licencas.Add(nomeLicenca, licenca);
                    return licenca;
                }
                catch (Exception e)
                {
                    throw new ExcecaoDeLicenciamento("Erro ao localizar licença.", e);
                }
            }

        }


        public void SalvarLicenca(Licenca licenca)
        {
            var localArquivo = LocalDoArquivo();
            var caminho = Path.GetDirectoryName(localArquivo);
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }
            var conteudoArquivo = CriptografiaAES.Criptografa(_hash, JsonSerializer.Serialize(licenca));
            File.WriteAllText(localArquivo, conteudoArquivo);
        }

        public string GerarHashDaLicenca(Licenca licenca)
        {
            return CriptografiaAES.Criptografa(_hash, JsonSerializer.Serialize(licenca));
        }

        public Licenca ObterLicencaDoHash(string hash)
        {
            return JsonSerializer.Deserialize<Licenca>(CriptografiaAES.Descriptografa(_hash, hash));
        }

        public void AtivarLicenca(string hash)
        {
            try
            {
                var licenca = ObterLicencaDoHash(hash);
                SalvarLicenca(licenca);
            }
            catch (Exception e)
            {
                throw new ExcecaoDeLicenciamento("Erro ao ativar licença", e);
            }
        }

        public bool LicencaExiste()
        {
            var nomeLicenca = NomeDaLicenca();
            if (nomeLicenca == null)
            {
                return false;
            }

            if (_licencas.ContainsKey(nomeLicenca))
            {
                return true;
            }

            var localDoArquivo = LocalDoArquivo();

            if (!String.IsNullOrEmpty(localDoArquivo))
            {
                return File.Exists(localDoArquivo);
            }
            return false;
        }

        protected abstract string LocalDoArquivo();
        protected abstract string NomeDaLicenca();
    }
}
