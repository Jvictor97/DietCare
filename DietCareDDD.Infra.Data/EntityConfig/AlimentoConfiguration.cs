using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography.X509Certificates;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class AlimentoConfiguration : EntityTypeConfiguration<Alimento>
    {
        public string TableName { get; } = "tb_Alimentos";

        public AlimentoConfiguration()
        {
            ToTable(TableName);

            HasKey(a => a.id_alimento);

            Property(a => a.alimento_calorias)
                .IsRequired();

            Property(a => a.alimento_nome)
                .IsRequired()
                .HasMaxLength(20);

            Property(a => a.alimento_porcao_base)
                .IsRequired();

            // Relacionamento: (N:1)
            HasRequired(a => a.Unidade)
                .WithMany()
                .HasForeignKey(u => u.id_unid);
        }
    }
}
