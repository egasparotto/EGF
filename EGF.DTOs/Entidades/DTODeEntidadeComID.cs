using System;

namespace EGF.DTOs.Entidades
{
    public class DTODeEntidadeComID<TID> : DTODeEntidade
        where TID : IComparable
    {
        public TID Id { get; set; }
    }
}
