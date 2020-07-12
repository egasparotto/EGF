using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dominio.Autenticacao.Usuarios.Repositorios
{
    public interface IRepositorioDeUsuario:IRepositorioComId<Usuario>
    {
    }
}
