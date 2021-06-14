using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Autenticacao.Perfis.Servicos;
using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Autenticacao.Usuarios.Servicos;
using EGF.ServicosDeAplicacao.Utils.Autenticacao;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace EGF.Dominio.Autenticacao.Extensoes
{
    public static class Extensao
    {

        public static void AdicionarServicosDeAutenticacao<TUsuario, TPerfil>(this IServiceCollection services)
            where TUsuario : Usuario
            where TPerfil : Perfil
        {
            AdicionarServicosDeAutenticacao<TUsuario, TPerfil>(services, null, null);
        }

        public static void AdicionarServicosDeAutenticacao<TUsuario, TPerfil>(this IServiceCollection services, Action<IdentityOptions> identityOptions)
            where TUsuario : Usuario
            where TPerfil : Perfil
        {
            AdicionarServicosDeAutenticacao<TUsuario, TPerfil>(services, identityOptions, null);
        }

        public static void AdicionarServicosDeAutenticacao<TUsuario, TPerfil>(this IServiceCollection services, Action<CookieAuthenticationOptions> cookieAuthenticationOptions)
            where TUsuario : Usuario
            where TPerfil : Perfil
        {
            AdicionarServicosDeAutenticacao<TUsuario, TPerfil>(services, null, cookieAuthenticationOptions);
        }

        public static void AdicionarServicosDeAutenticacao<TUsuario, TPerfil>(this IServiceCollection services, Action<IdentityOptions> identityOptions, Action<CookieAuthenticationOptions> cookieAuthenticationOptions)
            where TUsuario : Usuario
            where TPerfil : Perfil
        {
            if (identityOptions == null)
            {
                identityOptions = options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequiredUniqueChars = 1;
                    options.Lockout.MaxFailedAccessAttempts = 10;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                };
            }

            if (cookieAuthenticationOptions == null)
            {
                cookieAuthenticationOptions = options =>
                {
                    options.AccessDeniedPath = "/Home/PaginaNaoEncontrada";
                    options.Cookie.Name = "ChamaAlunoIdentidade";
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.LoginPath = "/Administracao/Conta/Login";
                    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                    options.SlidingExpiration = true;
                };
            }

            services.AddIdentity<TUsuario, TPerfil>().AddDefaultTokenProviders();
            services.AddScoped<IPasswordHasher<TUsuario>, CriptografiaDeSenha<TUsuario>>();
            services.AddTransient<IUserStore<TUsuario>, ServicoDeUsuario<TUsuario>>();
            services.AddTransient<IRoleStore<TPerfil>, ServicoDePerfil<TPerfil>>();
            services.AddTransient<IServicoDeUsuario<TUsuario>, ServicoDeUsuario<TUsuario>>();
            services.AddTransient<IServicoDePerfil<TPerfil>, ServicoDePerfil<TPerfil>>();
            services.AddTransient<UserManager<TUsuario>>();
            services.AddTransient<SignInManager<TUsuario>>();
            services.ConfigureApplicationCookie(cookieAuthenticationOptions);
            services.Configure(identityOptions);
        }
    }
}
