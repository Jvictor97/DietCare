using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class RefeicaoConfiguration : EntityTypeConfiguration<Refeicao>
    {
        public string TableName { get; } = "tb_Refeicoes";

        public RefeicaoConfiguration()
        {
            ToTable(TableName);

            HasKey(r => r.id_ref);

            Property(r => r.ref_nome)
                .IsRequired()
                .HasMaxLength(20);

            // Relacionamentos: (N:1)
            // Gera FK para id_diario
            HasRequired(r => r.Diario)
                .WithMany()
                .HasForeignKey(r => r.id_diario);
        }
    }
}
