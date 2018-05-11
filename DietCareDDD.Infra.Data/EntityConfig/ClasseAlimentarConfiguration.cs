using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Infra.Data.EntityConfig
{
    public class ClasseAlimentarConfiguration : EntityTypeConfiguration<ClasseAlimentar>
    {
        public string TableName { get; } = "tb_Classes_Alimentares";       

        public ClasseAlimentarConfiguration()
        {
            ToTable(TableName);

            HasKey(ca => ca.id_usu);

            Property(ca => ca.classe_tipo)
                .IsRequired()
                .HasMaxLength(45);

            // Relacionamento: (1:1)
            HasRequired<Usuario>(ca => ca.Usuario)
                .WithRequiredDependent(u => u.ClasseAlimentar);
        }
    }
}
