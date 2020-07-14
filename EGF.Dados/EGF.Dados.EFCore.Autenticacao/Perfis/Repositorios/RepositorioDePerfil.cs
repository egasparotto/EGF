using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Autenticacao.Perfis.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dados.EFCore.Autenticacao.Perfis.Repositorios
{
    public class RepositorioDePerfil : RepositorioComId<Perfil>, IRepositorioDePerfil
    {
        public RepositorioDePerfil(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }
    }
}
