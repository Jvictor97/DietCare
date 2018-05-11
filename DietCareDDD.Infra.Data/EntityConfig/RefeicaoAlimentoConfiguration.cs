using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class RefeicaoAlimentoConfiguration : EntityTypeConfiguration<RefeicaoAlimento>
    {
        public string TableName { get; } = "tb_Refeicao_Alimento";

        public RefeicaoAlimentoConfiguration()
        {
            ToTable(TableName);

            HasKey(ra => ra.id_ref_alimento);

            Property(ra => ra.ref_alimento_quantidade)
                .IsRequired();

            Property(ra => ra.id_unid)
                .IsRequired();

            Property(ra => ra.ref_alimento_calorias)
                .IsRequired();
            
            //Relacionamentos: (N:1)
            HasRequired(ra => ra.Refeicao)
                .WithMany()
                .HasForeignKey(ra => ra.id_ref);

            HasRequired(ra => ra.Alimento)
                .WithMany()
                .HasForeignKey(ra => ra.id_alimento);

            HasRequired(ra => ra.Unidade)
                .WithMany()
                .HasForeignKey(ra => ra.id_unid);
        }
    }
}
