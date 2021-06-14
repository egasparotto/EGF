using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Servicos;

using Microsoft.AspNetCore.Identity;

namespace EGF.Dominio.Autenticacao.Usuarios.Servicos
{
    public interface IServicoDeUsuario<TEntidade> : IServicoDePersistencia<int, TEntidade>, IUserStore<TEntidade>, IUserPasswordStore<TEntidade>, IUserEmailStore<TEntidade>, IUserRoleStore<TEntidade>
        where TEntidade: Usuario
    {
    }
}
