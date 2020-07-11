using EGF.Dominio.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGF.Dados.EFCore.Mapeamentos
{
    public abstract class MapeamentoBase<TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TEntidade : EntidadeBase
    {
        public void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            Mapear(builder);
        }

        protected abstract void Mapear(EntityTypeBuilder<TEntidade> builder);
    }
}
