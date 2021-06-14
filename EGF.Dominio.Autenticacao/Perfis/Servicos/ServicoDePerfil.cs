using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Autenticacao.Perfis.Repositorios;
using EGF.Dominio.Servicos;
using EGF.Dominio.UnidadesDeTrabalho;

using Microsoft.AspNetCore.Identity;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGF.Dominio.Autenticacao.Perfis.Servicos
{
    public class ServicoDePerfil<TEntidade> : ServicoDePersistencia<int, TEntidade, IRepositorioDePerfil<TEntidade>>, IServicoDePerfil<TEntidade>
        where TEntidade : Perfil
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }
        public ServicoDePerfil(IRepositorioDePerfil<TEntidade> repositorio, IUnidadeDeTrabalho unidadeDeTrabalho) : base(repositorio)
        {
            UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public async Task<IdentityResult> CreateAsync(TEntidade role, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.InserirAsync(role);
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

        public async Task<IdentityResult> DeleteAsync(TEntidade role, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.RemoverAsync(role);
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

        public async Task<TEntidade> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == Int32.Parse(roleId));
            return retorno.FirstOrDefault();
        }

        public async Task<TEntidade> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.CodigoInterno.ToUpper() == normalizedRoleName);
            return retorno.FirstOrDefault();
        }

        public async Task<string> GetNormalizedRoleNameAsync(TEntidade role, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == role.Id);
            return retorno.FirstOrDefault()?.CodigoInterno?.ToUpper();
        }

        public async Task<string> GetRoleIdAsync(TEntidade role, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == role.Id);
            return retorno.FirstOrDefault()?.Id.ToString();
        }

        public async Task<string> GetRoleNameAsync(TEntidade role, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == role.Id);
            return retorno.FirstOrDefault()?.Descricao.ToString();
        }

        public Task SetNormalizedRoleNameAsync(TEntidade role, string normalizedName, CancellationToken cancellationToken)
        {
            role.CodigoInterno = normalizedName;
            return Task.FromResult((object)null);
        }

        public Task SetRoleNameAsync(TEntidade role, string roleName, CancellationToken cancellationToken)
        {
            role.Descricao = roleName;
            return Task.FromResult((object)null);
        }

        public async Task<IdentityResult> UpdateAsync(TEntidade role, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.EditarAsync(role);
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
    }
}
