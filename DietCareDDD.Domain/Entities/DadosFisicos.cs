namespace DietCareDDD.Domain.Entities
{
    public class DadosFisicos
    {
        public float dados_peso { get; set; }

        public float dados_altura { get; set; }

        public int dados_idade { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
