using AutoMapper;

using EGF.Dominio.Entidades;
using EGF.DTOs.Entidades;
using EGF.DTOs.Mapeamentos.Base;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.DTOs.Mapeamentos.Entidades
{
    public class MapeadorDeDTODeEntidadeComId : MapeadorDeDTO<EntidadeComId, DTODeEntidadeComID>
    {
        public override void DTOParaEntidade(IMappingExpression<DTODeEntidadeComID, EntidadeComId> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .IncludeBase<DTODeEntidade,Entidade>();
        }

        public override void EntidadeParaDTO(IMappingExpression<EntidadeComId, DTODeEntidadeComID> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
                .IncludeBase<Entidade,DTODeEntidade>();
        }
    }
}
