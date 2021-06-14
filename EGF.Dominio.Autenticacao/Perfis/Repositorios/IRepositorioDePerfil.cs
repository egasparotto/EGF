using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Repositorios;

namespace EGF.Dominio.Autenticacao.Perfis.Repositorios
{
    public interface IRepositorioDePerfil<TEntidade> : IRepositorioComId<int,TEntidade>
        where TEntidade: Perfil
    {
    }
}
