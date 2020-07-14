using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Servicos;

using Microsoft.AspNetCore.Identity;

namespace EGF.Dominio.Autenticacao.Perfis.Servicos
{
    public interface IServicoDePerfil : IServicoDePersistencia<Perfil>, IRoleStore<Perfil>
    {
    }
}
