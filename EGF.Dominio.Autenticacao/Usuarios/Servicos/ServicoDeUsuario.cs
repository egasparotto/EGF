using EGF.Dominio.Autenticacao.Usuarios.Entidades;
using EGF.Dominio.Autenticacao.Usuarios.Repositorios;
using EGF.Dominio.Servicos;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dominio.Autenticacao.Usuarios.Servicos
{
    public class ServicoDeUsuario : ServicoDePersistencia<Usuario, IRepositorioDeUsuario>, IServicoDeUsuario
    {
        public ServicoDeUsuario(IRepositorioDeUsuario repositorio) : base(repositorio)
        {
        }
    }
}
