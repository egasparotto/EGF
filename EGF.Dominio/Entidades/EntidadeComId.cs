using System.ComponentModel.DataAnnotations;

namespace EGF.Dominio.Entidades
{
    public class EntidadeComId : Entidade
    {
        [Required]
        public int Id { get; set; }
    }
}
