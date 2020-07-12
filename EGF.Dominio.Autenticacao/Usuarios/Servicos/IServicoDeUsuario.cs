using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Servicos;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dominio.Autenticacao.Usuarios.Servicos
{
    public interface IServicoDeUsuario : IServicoDePersistencia<Usuario>, IUserStore<Usuario>, IUserPasswordStore<Usuario>, IUserEmailStore<Usuario>, IUserRoleStore<Usuario>
    {
    }
}
