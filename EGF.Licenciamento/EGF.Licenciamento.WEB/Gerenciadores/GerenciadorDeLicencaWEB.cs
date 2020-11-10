using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace EGF.Licenciamento.WEB.Gerenciadores
{
    public class GerenciadorDeLicencaWEB : GerenciadorDeLicenca
    {
        protected IConfiguration Configuration { get; }
        protected IHttpContextAccessor HttpContext { get; }
        public GerenciadorDeLicencaWEB(IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            Configuration = configuration;
            HttpContext = httpContext;
        }

        protected override string LocalDoArquivo()
        {
            if (Configuration != null)
            {
                var local = Configuration.GetSection("Licenciamento")?.GetSection("Local")?.Value;
                if (!string.IsNullOrEmpty(local))
                {
                    return Path.Combine(local, $"{NomeDaLicenca()}.licenca");
                }
            }
            return null;
        }

        protected override string NomeDaLicenca()
        {
            return HttpContext?.HttpContext?.Request?.Host.Host;
        }
    }
}
