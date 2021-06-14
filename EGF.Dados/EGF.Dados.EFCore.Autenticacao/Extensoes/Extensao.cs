using EGF.Dados.EFCore.Autenticacao.Perfis.Mapeamentos;
using EGF.Dados.EFCore.Autenticacao.Perfis.Repositorios;
using EGF.Dados.EFCore.Autenticacao.Usuarios.Mapeamentos;
using EGF.Dados.EFCore.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Autenticacao.Perfis.Repositorios;
using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EGF.Dados.EFCore.Autenticacao.Extensoes
{
    public static class Extensao
    {
        public static void MapearBancoDeDadosDeAutenticacao<TUsuario, TPerfil>(this ModelBuilder modelBuilder)
            where TUsuario: Usuario
            where TPerfil: Perfil
        {
            modelBuilder.ApplyConfiguration(new MapeamentoDeUsuario<TUsuario>());
            modelBuilder.ApplyConfiguration(new MapeamentoDePerfil<TPerfil>());
        }

        public static void AdicionarRepositoriosDeAutenticacao<TUsuario, TPerfil>(this IServiceCollection services)
            where TUsuario : Usuario
            where TPerfil : Perfil
        {
            services.AddScoped<IRepositorioDeUsuario<TUsuario>, RepositorioDeUsuario<TUsuario>>();
            services.AddScoped<IRepositorioDePerfil<TPerfil>, RepositorioDePerfil<TPerfil>>();
        }
    }
}
