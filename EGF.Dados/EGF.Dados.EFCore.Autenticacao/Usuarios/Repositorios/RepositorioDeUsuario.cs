using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

namespace EGF.Dados.EFCore.Autenticacao.Usuarios.Repositorios
{
    public class RepositorioDeUsuario<TEntidade> : RepositorioComId<int, TEntidade>, IRepositorioDeUsuario<TEntidade>
        where TEntidade: Usuario
    {
        public RepositorioDeUsuario(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }
    }
}
