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
        public static void AdicionarServicosDeAutenticacao(this IServiceCollection services, Action<IdentityOptions> identityOptions = null, Action<CookieAuthenticationOptions> cookieAuthenticationOptions = null)
        {
            if (identityOptions == null)
            {
                identityOptions = new Action<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequiredUniqueChars = 1;
                    options.Lockout.MaxFailedAccessAttempts = 10;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                });
            }

            if (cookieAuthenticationOptions == null)
            {
                cookieAuthenticationOptions = new Action<CookieAuthenticationOptions>(options =>
                {
                    options.AccessDeniedPath = "/Home/PaginaNaoEncontrada";
                    options.Cookie.Name = "ChamaAlunoIdentidade";
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.LoginPath = "/Administracao/Conta/Login";
                    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                    options.SlidingExpiration = true;
                });
            }

            services.AddIdentity<Usuario, Perfil>().AddDefaultTokenProviders();
            services.AddScoped<IPasswordHasher<Usuario>, CriptografiaDeSenha<Usuario>>();
            services.AddTransient<IUserStore<Usuario>, ServicoDeUsuario>();
            services.AddTransient<IRoleStore<Perfil>, ServicoDePerfil>();
            services.AddTransient<IServicoDeUsuario, ServicoDeUsuario>();
            services.AddTransient<IServicoDePerfil, ServicoDePerfil>();
            services.AddTransient<UserManager<Usuario>>();
            services.AddTransient<SignInManager<Usuario>>();
            services.ConfigureApplicationCookie(cookieAuthenticationOptions);
            services.Configure(identityOptions);
        }
    }
}
