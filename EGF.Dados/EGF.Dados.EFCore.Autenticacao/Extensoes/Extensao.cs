using EGF.Dados.EFCore.Autenticacao.Perfis.Mapeamentos;
using EGF.Dados.EFCore.Autenticacao.Perfis.Repositorios;
using EGF.Dados.EFCore.Autenticacao.Usuarios.Mapeamentos;
using EGF.Dados.EFCore.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.Autenticacao.Perfis.Repositorios;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EGF.Dados.EFCore.Autenticacao.Extensoes
{
    public static class Extensao
    {
        public static void MapearBancoDeDadosDeAutenticacao(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoDeUsuario());
            modelBuilder.ApplyConfiguration(new MapeamentoDePerfil());
        }

        public static void AdicionarRepositoriosDeAutenticacao(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioDeUsuario, RepositorioDeUsuario>();
            services.AddScoped<IRepositorioDePerfil, RepositorioDePerfil>();
        }
    }
}
