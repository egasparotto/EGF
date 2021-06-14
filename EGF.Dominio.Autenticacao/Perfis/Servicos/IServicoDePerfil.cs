using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Servicos;

using Microsoft.AspNetCore.Identity;

namespace EGF.Dominio.Autenticacao.Perfis.Servicos
{
    public interface IServicoDePerfil<TEntidade> : IServicoDePersistencia<int, TEntidade>, IRoleStore<TEntidade>
        where TEntidade : Perfil
    {
    }
}
