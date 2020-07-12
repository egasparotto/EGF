using EGF.Dominio.Entidades;

using System.ComponentModel;

namespace EGF.Dominio.Autenticacao.Usuarios.Entidades
{
    public class Usuario: EntidadeComId
    {
        [Description("Email")]
        public string Email { get; set; }
        [Description("Senha")]
        public string Senha { get; set; }
        [Description("Email Confirmado")]
        public bool EmailConfirmado { get; set; }
    }
}
