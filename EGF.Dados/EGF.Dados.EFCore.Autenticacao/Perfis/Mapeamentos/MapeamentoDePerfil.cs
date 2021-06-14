using EGF.Dados.EFCore.Mapeamentos;
using EGF.Dominio.Autenticacao.Perfis.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGF.Dados.EFCore.Autenticacao.Perfis.Mapeamentos
{
    public class MapeamentoDePerfil<TEntidade> : Mapeamento<TEntidade>
        where TEntidade: Perfil
    {
        protected override void Mapear(EntityTypeBuilder<TEntidade> builder)
        {
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.CodigoInterno).HasColumnName("CODIGOINTERNO");
            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO");
            builder.ToTable("PERFIS").HasKey(x => x.Id);
        }
    }
}
