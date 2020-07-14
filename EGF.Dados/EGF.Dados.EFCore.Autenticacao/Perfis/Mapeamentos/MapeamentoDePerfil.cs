using EGF.Dados.EFCore.Mapeamentos;
using EGF.Dominio.Autenticacao.Perfis.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace EGF.Dados.EFCore.Autenticacao.Perfis.Mapeamentos
{
    public class MapeamentoDePerfil : Mapeamento<Perfil>
    {
        protected override void Mapear(EntityTypeBuilder<Perfil> builder)
        {
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.CodigoInterno).HasColumnName("CODIGOINTERNO");
            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO");
            builder.ToTable("PERFIS").HasKey(x => x.Id);
        }
    }
}
