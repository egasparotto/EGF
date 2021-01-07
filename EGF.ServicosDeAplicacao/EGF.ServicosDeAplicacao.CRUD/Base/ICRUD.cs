using EGF.DTOs.Entidades;

using System.Collections.Generic;

namespace EGF.ServicosDeAplicacao.CRUD.Base
{
    public interface ICRUD<TDTO>
        where TDTO : DTODeEntidade
    {
        TDTO Inserir(TDTO dto);
        TDTO Editar(TDTO dto);
        void Remover(TDTO dto);
        IEnumerable<TDTO> ObterTodos();
        TDTO ObterPorId(int id);
    }
}
