using EGF.Dominio.Entidades;

using System.ComponentModel;

namespace EGF.Dominio.Autenticacao.Perfis.Entidades
{
    public class Perfil : EntidadeComId<int>
    {
        [Description("Descrição")]
        public string Descricao { get; set; }
        [Description("Código Interno")]
        public string CodigoInterno { get; set; }
    }
}
