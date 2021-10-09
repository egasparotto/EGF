using EGF.Licenciamento.Core.Licencas.Entidades;
using EGF.ServicosDeAplicacao.Utils.Criptografia;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EGF.Licenciamento.Core.Licencas.Gerenciadores
{
    public abstract class GerenciadorDeLicencaBase : IGerenciadorDeLicenca
    {
        protected readonly IDictionary<string, Licenca> _licencas;
        protected readonly string _hash = "c60550e57da69b59e21134418a6c1e9d";

        protected GerenciadorDeLicencaBase()
        {
            _licencas = new Dictionary<string, Licenca>();
        }

        protected abstract string NomeDaLicenca();
        protected abstract Licenca ObterLicencaSemCache();


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
                licenca = ObterLicencaSemCache();
                _licencas.Add(nomeLicenca, licenca);
                return licenca;
            }
        }


        public string GerarHashDaLicenca(Licenca licenca)
        {
            return CriptografiaAES.Criptografa(_hash, JsonSerializer.Serialize(licenca));
        }

        public Licenca ObterLicencaDoHash(string hash)
        {
            return JsonSerializer.Deserialize<Licenca>(CriptografiaAES.Descriptografa(_hash, hash));
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

            try
            {
                var licenca = ObterLicenca();
                return licenca != null;
            }
            catch
            {
                return false;
            }
        }

    }
}
