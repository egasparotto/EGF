using EGF.Dados.EFCore.Autenticacao.Usuarios.Mapeamentos;
using EGF.Dados.EFCore.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dados.EFCore.Autenticacao.Extensoes
{
    public static class Extensao
    {
        public static void MapearBancoDeDadosDeAutenticacao(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoDeUsuario());
        }

        public static void AdicionarRepositoriosDeAutenticacao(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioDeUsuario, RepositorioDeUsuario>();
        }
    }
}
