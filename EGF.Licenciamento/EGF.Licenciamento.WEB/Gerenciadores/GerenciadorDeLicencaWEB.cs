using EGF.Licenciamento.Core.Licencas.Entidades;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;

namespace EGF.Licenciamento.WEB.Gerenciadores
{
    public class GerenciadorDeLicencaWEB : GerenciadorDeLicencaBase
    {
        protected IConfiguration Configuration { get; }
        protected IHttpContextAccessor HttpContext { get; }
        protected IHttpClientFactory ClientFactory { get; }
        protected string Url { get;  }

        public GerenciadorDeLicencaWEB(IConfiguration configuration, 
                                       IHttpContextAccessor httpContext,
                                       IHttpClientFactory clientFactory,
                                       string url)
        {
            Configuration = configuration;
            HttpContext = httpContext;
            ClientFactory = clientFactory;
            Url = url;
        }

        protected override string NomeDaLicenca()
        {
            var identity = HttpContext.HttpContext.User.Identity as ClaimsIdentity;

            var idEmpresa = identity.Claims.Where(x => x.Type == "empresa").FirstOrDefault()?.Value;

            if (string.IsNullOrEmpty(idEmpresa))
            {
                throw new System.Exception("Id da empresa não encontrado");  
            }

            return idEmpresa;
        }

        protected override Licenca ObterLicencaSemCache()
        {            
            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            request.Headers.Add("Authorization", HttpContext.HttpContext.Request.Headers["Authorization"].ToString());

            var client = ClientFactory.CreateClient();

            var response = client.Send(request);

            var stream = response.Content.ReadAsStream();

            var stringLicenca = new StreamReader(stream).ReadToEnd();

            return JsonSerializer.Deserialize<Licenca>(stringLicenca);
        }
    }
}
