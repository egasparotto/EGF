using EGF.Dominio.Entidades;
using EGF.DTOs.Entidades;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.ServicosDeAplicacao.CRUD.Base
{
    interface ICRUD<TDTO>
        where TDTO : DTODeEntidade
    {
        TDTO Inserir(TDTO dto);
        TDTO Editar(TDTO dto);
        void Remover(TDTO dto);
    }
}
