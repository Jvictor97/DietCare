using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class UnidadeConfiguration : EntityTypeConfiguration<Unidade>
    {
        public string TableName { get; } = "tb_Unidades";

        public UnidadeConfiguration()
        {
            ToTable(TableName);

            HasKey(u => u.id_unid);

            Property(u => u.unid_simbolo)
                .IsRequired()
                .HasMaxLength(10);

            Property(u => u.unid_descricao)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
