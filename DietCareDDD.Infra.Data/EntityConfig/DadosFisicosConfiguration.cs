using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class DadosFisicosConfiguration : EntityTypeConfiguration<DadosFisicos>
    {
        public string TableName { get; } = "tb_Dados_Fisicos";

        public DadosFisicosConfiguration()
        {
            ToTable(TableName);

            HasKey(df => df.id_usu);

            // Relacionamento: (1:1)
            HasRequired(df => df.Usuario)
                .WithRequiredDependent(u => u.DadosFisicos);
        }
    }
}
