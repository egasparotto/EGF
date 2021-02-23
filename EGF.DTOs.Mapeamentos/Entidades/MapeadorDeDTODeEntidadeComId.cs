using AutoMapper;

using EGF.Dominio.Entidades;
using EGF.DTOs.Entidades;
using EGF.DTOs.Mapeamentos.Base;

using System;

namespace EGF.DTOs.Mapeamentos.Entidades
{
    public class MapeadorDeDTODeEntidadeComId<TID> : MapeadorDeDTO<EntidadeComId<TID>, DTODeEntidadeComID<TID>>
        where TID : IComparable
    {
        public override void DTOParaEntidade(IMappingExpression<DTODeEntidadeComID<TID>, EntidadeComId<TID>> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .IncludeBase<DTODeEntidade, Entidade>();
        }

        public override void EntidadeParaDTO(IMappingExpression<EntidadeComId<TID>, DTODeEntidadeComID<TID>> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .IncludeBase<Entidade, DTODeEntidade>();
        }
    }
}
