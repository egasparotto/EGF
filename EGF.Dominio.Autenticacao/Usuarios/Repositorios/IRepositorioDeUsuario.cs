using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Repositorios;

namespace EGF.Dominio.Autenticacao.Usuarios.Repositorios
{
    public interface IRepositorioDeUsuario<TEntidade> : IRepositorioComId<int,TEntidade>
        where TEntidade: Usuario
    {
    }
}
