using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class RestricaoConfiguration : EntityTypeConfiguration<Restricao>
    {
        public string TableName { get; } = "tb_Restricoes";

        public RestricaoConfiguration()
        {
            ToTable(TableName);

            HasKey(r => r.id_rest);

            Property(r => r.id_usu)
                .IsRequired();

            Property(r => r.id_alimento)
                .IsRequired();

            // Relacionamentos: (N:1)
            HasRequired(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.id_usu);

            HasRequired(r => r.Alimento)
                .WithMany()
                .HasForeignKey(r => r.id_alimento);
        }
    }
}
