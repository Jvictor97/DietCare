using DietCareDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration :EntityTypeConfiguration<Usuario>
    {
        public string TableName { get; } = "tb_Usuarios";

        public UsuarioConfiguration()
        {
            ToTable(TableName);

            HasKey(u => u.id_usu);

            Property(u => u.usu_email)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.usu_login)
                .IsRequired()
                .HasMaxLength(20);

            Property(u => u.usu_senha)
                .IsRequired()
                .HasMaxLength(20);

            Property(u => u.usu_nome)
                .IsRequired();
        }
    }
}
