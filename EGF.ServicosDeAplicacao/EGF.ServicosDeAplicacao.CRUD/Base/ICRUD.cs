using EGF.DTOs.Entidades;

using System;
using System.Collections.Generic;

namespace EGF.ServicosDeAplicacao.CRUD.Base
{
    public interface ICRUD<TID,TDTO>
        where TID : IComparable
        where TDTO : DTODeEntidade
    {
        TDTO Inserir(TDTO dto);
        TDTO Editar(TDTO dto);
        void Remover(TDTO dto);
        IEnumerable<TDTO> ObterTodos();
        TDTO ObterPorId(TID id);
    }
}
