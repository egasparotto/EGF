using EGF.Dados.EFCore.Mapeamentos;
using EGF.Dominio.Autenticacao.Usuarios.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGF.Dados.EFCore.Autenticacao.Usuarios.Mapeamentos
{
    public class MapeamentoDeUsuario : Mapeamento<Usuario>
    {
        protected override void Mapear(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Email).HasColumnName("EMAIL");
            builder.Property(x => x.Senha).HasColumnName("SENHA");
            builder.Property(x => x.EmailConfirmado).HasColumnName("EMAILCONFIRMADO");
            builder.Property(x => x.IdDoPerfil).HasColumnName("IDDOPERFIL");

            builder.HasOne(x => x.Perfil).WithMany().HasForeignKey(x => x.IdDoPerfil).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("USUARIOS").HasKey(x => x.Id);
        }
    }
}
