using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dados.EFCore.Autenticacao.Usuarios.Repositorios
{
    public class RepositorioDeUsuario : RepositorioComId<Usuario>, IRepositorioDeUsuario
    {
        public RepositorioDeUsuario(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }
    }
}
