using System;
using System.ComponentModel.DataAnnotations;

namespace EGF.Dominio.Entidades
{
    public class EntidadeComId<TID> : Entidade
        where TID: IComparable
    {
        [Required]
        public TID Id { get; set; }
    }
}
