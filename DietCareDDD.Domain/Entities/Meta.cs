namespace DietCareDDD.Domain.Entities
{
    public class Meta
    {
        public int meta_calorias { get; set; }

        public float meta_carboidratos { get; set; }

        public float meta_proteinas { get; set; }

        public float meta_gorduras { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
