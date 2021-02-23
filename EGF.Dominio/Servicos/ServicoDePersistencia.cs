using EGF.Dominio.Entidades;
using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;

namespace EGF.Dominio.Servicos
{
    public abstract class ServicoDePersistencia<TID, TEntidade, TRepositorio> : IServicoDePersistencia<TID,TEntidade>
        where TID : IComparable
        where TRepositorio : IRepositorioComId<TID,TEntidade>
        where TEntidade : EntidadeComId<TID>
    {
        protected TRepositorio Repositorio { get; }

        protected ServicoDePersistencia(TRepositorio repositorio)
        {
            Repositorio = repositorio;
        }

        public virtual IEnumerable<TEntidade> Buscar()
        {
            return Repositorio.Buscar();
        }

        public virtual IEnumerable<TEntidade> Buscar(Func<TEntidade, bool> pesquisa)
        {
            return Repositorio.Buscar(pesquisa);
        }

        public virtual TEntidade Inserir(TEntidade entidade)
        {
            return Repositorio.Inserir(entidade);
        }

        public virtual TEntidade Editar(TEntidade entidade)
        {
            return Repositorio.Editar(entidade);
        }

        public virtual void Remover(TEntidade entidade)
        {
            Repositorio.Remover(entidade);
        }

        public TEntidade ObterPorID(TID id)
        {
            return Repositorio.ObterPorId(id);
        }
    }
}
