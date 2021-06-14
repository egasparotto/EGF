using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.Servicos;
using EGF.Dominio.UnidadesDeTrabalho;
using EGF.ServicosDeAplicacao.Utils.Autenticacao;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGF.Dominio.Autenticacao.Usuarios.Servicos
{
    public class ServicoDeUsuario<TEntidade> : ServicoDePersistencia<int,TEntidade, IRepositorioDeUsuario<TEntidade>>, IServicoDeUsuario<TEntidade>
        where TEntidade: Usuario
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }

        public ServicoDeUsuario(IRepositorioDeUsuario<TEntidade> repositorio, IUnidadeDeTrabalho unidadeDeTrabalho) : base(repositorio)
        {
            UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public override TEntidade Inserir(TEntidade entidade)
        {
            if (entidade != null)
            {
                if (!string.IsNullOrEmpty(entidade.Senha))
                {
                    entidade.Senha = Criptografia.Criptografa(entidade.Senha);
                }
            }
            return base.Inserir(entidade);
        }

        public override TEntidade Editar(TEntidade entidade)
        {
            var registroAntigo = UnidadeDeTrabalho.Contexto.ObterAntesDaAlteracao(entidade);
            if (entidade != null)
            {
                if (entidade.Senha == null || entidade.Senha == registroAntigo.Senha)
                {
                    entidade.Senha = registroAntigo.Senha;
                }
                else
                {
                    entidade.Senha = Criptografia.Criptografa(entidade.Senha);
                }
            }
            return base.Editar(entidade);
        }

        public async Task<IdentityResult> CreateAsync(TEntidade user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.InserirAsync(user);
                UnidadeDeTrabalho.Commit();
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError();
                error.Description = e.Message;
                return IdentityResult.Failed(error);
            }
        }

        public async Task<IdentityResult> DeleteAsync(TEntidade user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.RemoverAsync(user);
                UnidadeDeTrabalho.Commit();
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

        public async Task<TEntidade> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Email.ToUpper() == normalizedEmail);
            return retorno.FirstOrDefault();
        }

        public async Task<TEntidade> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == Int32.Parse(userId));
            return retorno.FirstOrDefault();
        }

        public async Task<TEntidade> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Email.ToUpper() == normalizedUserName);
            return retorno.FirstOrDefault();
        }

        public async Task<string> GetEmailAsync(TEntidade user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Email;
        }

        public async Task<bool> GetEmailConfirmedAsync(TEntidade user, CancellationToken cancellationToken)
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

        public async Task<string> GetNormalizedEmailAsync(TEntidade user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Email?.ToUpper();
        }

        public async Task<string> GetNormalizedUserNameAsync(TEntidade user, CancellationToken cancellationToken)
        {
            return await GetNormalizedEmailAsync(user, cancellationToken).ConfigureAwait(false);
        }

        public async Task<string> GetPasswordHashAsync(TEntidade user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Senha;
        }

        public async Task<string> GetUserIdAsync(TEntidade user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Id.ToString();
        }

        public async Task<string> GetUserNameAsync(TEntidade user, CancellationToken cancellationToken)
        {
            return await GetEmailAsync(user, cancellationToken).ConfigureAwait(false);
        }

        public async Task<bool> HasPasswordAsync(TEntidade user, CancellationToken cancellationToken)
        {
            var senha = await GetPasswordHashAsync(user, cancellationToken).ConfigureAwait(false);
            return !String.IsNullOrEmpty(senha);
        }

        public Task SetEmailAsync(TEntidade user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult((object)null);
        }

        public Task SetEmailConfirmedAsync(TEntidade user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmado = confirmed;
            return Task.FromResult((object)null);
        }

        public Task SetNormalizedEmailAsync(TEntidade user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.Email = normalizedEmail;
            return Task.FromResult((object)null);
        }

        public Task SetNormalizedUserNameAsync(TEntidade user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Email = normalizedName;
            return Task.FromResult((object)null);
        }

        public Task SetPasswordHashAsync(TEntidade user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Senha = passwordHash;
            return Task.FromResult((object)null);
        }

        public Task SetUserNameAsync(TEntidade user, string userName, CancellationToken cancellationToken)
        {
            user.Email = userName;
            return Task.FromResult((object)null);
        }

        public async Task<IdentityResult> UpdateAsync(TEntidade user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.EditarAsync(user);
                UnidadeDeTrabalho.Commit();

                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError();
                error.Description = e.Message;
                return IdentityResult.Failed(error);
            }
        }

        public Task AddToRoleAsync(TEntidade user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(TEntidade user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(TEntidade user, CancellationToken cancellationToken)
        {
            var perfil = await Task.FromResult(user.Perfil.CodigoInterno).ConfigureAwait(false);
            return new List<string> { perfil };
        }

        public async Task<bool> IsInRoleAsync(TEntidade user, string roleName, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Perfil.CodigoInterno == roleName).ConfigureAwait(false);
        }

        public async Task<IList<TEntidade>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var usuarios = await Repositorio.BuscarAsync(x => x.Perfil.CodigoInterno == roleName);
            return usuarios.ToList();
        }

    }
}
