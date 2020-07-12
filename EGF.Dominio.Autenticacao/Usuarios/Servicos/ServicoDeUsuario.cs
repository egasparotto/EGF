using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.Servicos;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EGF.Dominio.Autenticacao.Usuarios.Servicos
{
    public class ServicoDeUsuario : ServicoDePersistencia<Usuario, IRepositorioDeUsuario>, IServicoDeUsuario
    {
        public ServicoDeUsuario(IRepositorioDeUsuario repositorio) : base(repositorio)
        {
        }

        public async Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.InserirAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError();
                error.Description = e.Message;
                return IdentityResult.Failed(error);
            }
        }

        public async Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.RemoverAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError();
                error.Description = e.Message;
                return IdentityResult.Failed(error);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Usuario> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Email.ToUpper() == normalizedEmail);
            return retorno.FirstOrDefault();
        }

        public async Task<Usuario> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == Int32.Parse(userId));
            return retorno.FirstOrDefault();
        }

        public async Task<Usuario> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Email.ToUpper() == normalizedUserName);
            return retorno.FirstOrDefault();
        }

        public async Task<string> GetEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Email;
        }

        public async Task<bool> GetEmailConfirmedAsync(Usuario user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            var Usuario = retorno.FirstOrDefault();
            if (Usuario != null)
            {
                return Usuario.EmailConfirmado;
            }
            else
            {
                return true;
            }
        }

        public async Task<string> GetNormalizedEmailAsync(Usuario user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Email?.ToUpper();
        }

        public async Task<string> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            return await GetNormalizedEmailAsync(user, cancellationToken);
        }

        public async Task<string> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Senha;
        }

        public async Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Id.ToString();
        }

        public async Task<string> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        {
            return await GetEmailAsync(user, cancellationToken);
        }

        public async Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        {
            var senha = await GetPasswordHashAsync(user, cancellationToken);
            return !String.IsNullOrEmpty(senha);
        }

        public Task SetEmailAsync(Usuario user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult((object)null);
        }

        public Task SetEmailConfirmedAsync(Usuario user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmado = confirmed;
            return Task.FromResult((object)null);
        }

        public Task SetNormalizedEmailAsync(Usuario user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.Email = normalizedEmail;
            return Task.FromResult((object)null);
        }

        public Task SetNormalizedUserNameAsync(Usuario user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Email = normalizedName;
            return Task.FromResult((object)null);
        }

        public Task SetPasswordHashAsync(Usuario user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Senha = passwordHash;
            return Task.FromResult((object)null);
        }

        public Task SetUserNameAsync(Usuario user, string userName, CancellationToken cancellationToken)
        {
            user.Email = userName;
            return Task.FromResult((object)null);
        }

        public async Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.EditarAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError();
                error.Description = e.Message;
                return IdentityResult.Failed(error);
            }
        }

        public Task AddToRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(Usuario user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var perfil = await Task.FromResult(user.Perfil.CodigoInterno);
            //return new List<string>() { perfil };
        }

        public async Task<bool> IsInRoleAsync(Usuario user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await Task.FromResult(user.Perfil.CodigoInterno == roleName);
        }

        public async Task<IList<Usuario>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var usuarios = await Repositorio.BuscarAsync(x => x.Perfil.CodigoInterno == roleName);
            //return usuarios.ToList();
        }

    }
}
