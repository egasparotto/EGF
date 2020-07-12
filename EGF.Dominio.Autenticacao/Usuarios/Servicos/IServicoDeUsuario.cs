using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Servicos;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dominio.Autenticacao.Usuarios.Servicos
{
    public interface IServicoDeUsuario : IServicoDePersistencia<Usuario>
    {
    }
}
