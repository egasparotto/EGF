using AutoMapper;

using EGF.Dominio.Entidades;
using EGF.DTOs.Entidades;
using EGF.DTOs.Mapeamentos.Base;

namespace EGF.DTOs.Mapeamentos.Entidades
{
    public class MapeadorDeDTODeEntidade : MapeadorDeDTO<Entidade, DTODeEntidade>
    {
        public override void DTOParaEntidade(IMappingExpression<DTODeEntidade, Entidade> mapeamento)
        {
        }

        public override void EntidadeParaDTO(IMappingExpression<Entidade, DTODeEntidade> mapeamento)
        {
        }
    }
}
