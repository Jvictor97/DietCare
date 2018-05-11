using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class MetaConfiguration : EntityTypeConfiguration<Meta>
    {
        public string TableName { get; } = "tb_Metas";

        public MetaConfiguration()
        {
            ToTable(TableName);

            HasKey(m => m.id_usu);

            Property(m => m.meta_calorias)
                .IsRequired();

            Property(m => m.meta_carboidratos)
                .IsRequired();

            Property(m => m.meta_proteinas)
                .IsRequired();

            Property(m => m.meta_gorduras)
                .IsRequired();

            // Relacionamentos: (1:1)
            HasRequired<Usuario>(m => m.Usuario)
                .WithRequiredDependent(u => u.Meta);
        }
    }
}