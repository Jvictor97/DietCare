namespace DietCareDDD.Domain.Entities
{
    public class ClasseAlimentar
    {
        public string classe_tipo { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
