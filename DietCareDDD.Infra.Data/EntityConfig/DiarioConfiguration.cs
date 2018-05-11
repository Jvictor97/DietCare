using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class DiarioConfiguration : EntityTypeConfiguration<Diario>
    {
        public string TableName { get; } = "tb_Diarios";

        public DiarioConfiguration()
        {
            ToTable(TableName);

            HasKey(d => d.id_diario);

            Property(d => d.diario_dia)
                .IsRequired();
            
            // Relacionamentos: (N:1)
            HasRequired(d => d.Usuario)
                .WithMany(u => u.Diarios)
                .HasForeignKey(d => d.id_usu);
        }
    }
}
