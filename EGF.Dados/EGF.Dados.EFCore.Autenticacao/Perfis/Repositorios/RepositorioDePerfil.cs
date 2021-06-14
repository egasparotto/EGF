using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Autenticacao.Perfis.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

namespace EGF.Dados.EFCore.Autenticacao.Perfis.Repositorios
{
    public class RepositorioDePerfil<TEntidade> : RepositorioComId<int,TEntidade>, IRepositorioDePerfil<TEntidade>
        where TEntidade: Perfil
    {
        public RepositorioDePerfil(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }
    }
}
