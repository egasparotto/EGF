using EGF.Dominio.Autenticacao.Usuarios.Servicos;

using Microsoft.Extensions.DependencyInjection;

namespace EGF.Dominio.Autenticacao.Extensoes
{
    public static class Extensao
    {
        public static void AdicionarServicosDeAutenticacao(this IServiceCollection services)
        {
            services.AddScoped<IServicoDeUsuario, ServicoDeUsuario>();
        }
    }
}
