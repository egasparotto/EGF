using AutoMapper;

using EGF.Dominio.Entidades;
using EGF.Dominio.Servicos;
using EGF.Dominio.UnidadesDeTrabalho;
using EGF.DTOs.Entidades;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.ServicosDeAplicacao.CRUD.Base
{
    public abstract class CRUD<TEntidade, TServico, TDTO> : ICRUD<TDTO>
        where TEntidade : Entidade
        where TServico : IServicoDePersistencia<TEntidade>
        where TDTO : DTODeEntidade
    {
        protected TServico Servico { get; }
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; }
        protected IMapper Mapeador { get; }

        public CRUD(TServico servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador)
        {
            Servico = servico;
            UnidadeDeTrabalho = unidadeDeTrabalho;
            Mapeador = mapeador;
        }

        public virtual TDTO Inserir(TDTO dto)
        {
            var entidade = Mapeador.Map<TEntidade>(dto);
            entidade = Servico.Inserir(entidade);
            UnidadeDeTrabalho.Commit();
            return Mapeador.Map<TDTO>(entidade);
        }

        public virtual TDTO Editar(TDTO dto)
        {
            var entidade = Mapeador.Map<TEntidade>(dto);
            entidade = Servico.Editar(entidade);
            UnidadeDeTrabalho.Commit();
            return Mapeador.Map<TDTO>(entidade);
        }

        public virtual void Remover(TDTO dto)
        {
            var entidade = Mapeador.Map<TEntidade>(dto);
            Servico.Remover(entidade);
            UnidadeDeTrabalho.Commit();
        }
    }
}
