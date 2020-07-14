using EGF.DTOs.Entidades;

namespace EGF.ServicosDeAplicacao.CRUD.Base
{
    public interface ICRUD<TDTO>
        where TDTO : DTODeEntidade
    {
        TDTO Inserir(TDTO dto);
        TDTO Editar(TDTO dto);
        void Remover(TDTO dto);
    }
}
