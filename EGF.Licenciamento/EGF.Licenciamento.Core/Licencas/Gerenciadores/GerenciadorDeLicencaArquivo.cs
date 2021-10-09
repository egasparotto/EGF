
using EGF.Excecoes;
using EGF.Licenciamento.Core.Licencas.Entidades;
using EGF.ServicosDeAplicacao.Utils.Criptografia;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;



namespace EGF.Licenciamento.Core.Licencas.Gerenciadores
{
    public abstract class GerenciadorDeLicencaArquivo : GerenciadorDeLicencaBase, IGerenciadorDeLicenca
    {
        protected override Licenca ObterLicencaSemCache()
        {
            try
            {
                var localArquivo = LocalDoArquivo();
                if (!File.Exists(localArquivo))
                {
                    throw new FileNotFoundException("Erro ao localizar o arquivo: " + localArquivo);
                }
                var conteudoArquivo = CriptografiaAES.Descriptografa(_hash, File.ReadAllText(localArquivo));
                return JsonSerializer.Deserialize<Licenca>(conteudoArquivo);

            }
            catch (Exception e)
            {
                throw new ExcecaoDeLicenciamento("Erro ao localizar licença.", e);
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

        protected abstract string LocalDoArquivo();
    }
}
