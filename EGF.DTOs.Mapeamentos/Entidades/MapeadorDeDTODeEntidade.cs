using AutoMapper;

using EGF.Dominio.Entidades;
using EGF.DTOs.Entidades;
using EGF.DTOs.Mapeamentos.Base;

namespace EGF.DTOs.Mapeamentos.Entidades
{
    public abstract class MapeadorDeDTODeEntidade : MapeadorDeDTO<Entidade, DTODeEntidade>
    {
    }
}
