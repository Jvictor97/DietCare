namespace DietCareDDD.Domain.Entities
{
    public class Restricao
    {
        public int id_rest { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int id_alimento { get; set; }
        public virtual Alimento Alimento { get; set; }
    }
}
