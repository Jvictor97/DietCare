namespace DietCareDDD.Domain.Entities
{
    public class Alimento
    {
        public int id_alimento { get; set; }

        public string alimento_nome { get; set; }

        public int alimento_calorias { get; set; }

        public float alimento_carboidratos { get; set; }

        public float alimento_proteinas { get; set; }

        public float alimento_gorduras { get; set; }

        public float alimento_porcao_base { get; set; }

        // Relacionamentos:
        public int id_unid { get; set; }
        public virtual Unidade Unidade { get; set; }
    }
}
