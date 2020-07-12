using AutoMapper;

using EGF.Dominio.Entidades;
using EGF.DTOs.Entidades;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.DTOs.Mapeamentos.Base
{
    public abstract class MapeadorDeDTO<TEntidade, TDTO> : Profile
            where TEntidade : Entidade
            where TDTO : DTODeEntidade
    {
        protected MapeadorDeDTO()
        {
            EntidadeParaDTO(CreateMap<TEntidade, TDTO>());
            DTOParaEntidade(CreateMap<TDTO,TEntidade>());
        }

        public abstract void EntidadeParaDTO(IMappingExpression<TEntidade, TDTO> mapeamento);
        public abstract void DTOParaEntidade(IMappingExpression<TDTO, TEntidade> mapeamento);
    }
}
