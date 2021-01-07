using AutoMapper;

using EGF.Dominio.Entidades;
using EGF.Dominio.Servicos;
using EGF.Dominio.UnidadesDeTrabalho;
using EGF.DTOs.Entidades;

using System.Collections.Generic;

namespace EGF.ServicosDeAplicacao.CRUD.Base
{
    public abstract class CRUD<TEntidade, TServico, TDTO> : ICRUD<TDTO>
        where TEntidade : EntidadeComId
        where TServico : IServicoDePersistencia<TEntidade>
        where TDTO : DTODeEntidadeComID
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

        public virtual IEnumerable<TDTO> ObterTodos()
        {
            var lista = Servico.Buscar();
            return Mapeador.Map<IEnumerable<TDTO>>(lista);
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
            var entidade = Servico.ObterPorID(dto.Id);
            if(entidade == null)
            {
                throw new System.Exception("Entidade não localizada para edição");
            }
            entidade = Mapeador.Map(dto, entidade);
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

        public virtual TDTO ObterPorId(int id)
        {
            return Mapeador.Map<TDTO>(Servico.ObterPorID(id));
        }
    }
}
