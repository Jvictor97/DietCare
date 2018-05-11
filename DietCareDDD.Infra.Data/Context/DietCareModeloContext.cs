using DietCareDDD.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DietCareDDD.Infra.Data.EntityConfig;

namespace DietCareDDD.Infra.Data.Context
{
    public class DietCareContext : DbContext
    {
        public DietCareContext()
            :base("DietCareModeloDDD")
        {
        }

        public DbSet<Alimento> Alimentos { get; set; }
        public DbSet<ClasseAlimentar> ClassesAlimentares { get; set; }
        public DbSet<DadosFisicos> DadosFisicos { get; set; }
        public DbSet<Diario> Diarios { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Refeicao> Refeicoes { get; set; }
        public DbSet<RefeicaoAlimento> RefeicoesAlimentos { get; set; }
        public DbSet<Restricao> Restricoes { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Remove a pluralização da nomenclatura da tabela
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Remove o Cascade na deleção de um registro pai
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name.Substring(0, 2) == "id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new AlimentoConfiguration());
            modelBuilder.Configurations.Add(new ClasseAlimentarConfiguration());
            modelBuilder.Configurations.Add(new DadosFisicosConfiguration());
            modelBuilder.Configurations.Add(new DiarioConfiguration());
            modelBuilder.Configurations.Add(new MetaConfiguration());
            modelBuilder.Configurations.Add(new RefeicaoAlimentoConfiguration());
            modelBuilder.Configurations.Add(new RefeicaoConfiguration());
            modelBuilder.Configurations.Add(new RestricaoConfiguration());
            modelBuilder.Configurations.Add(new UnidadeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());

        }
    }
}
