using System.Collections.Generic;

namespace DietCareDDD.Domain.Entities
{
    public class Refeicao
    {
        public int id_ref { get; set; }

        public string ref_nome { get; set; }

        //Relacionamentos:
        public int id_diario { get; set; }
        public virtual Diario Diario { get; set; }

        public virtual List<RefeicaoAlimento> RefeicaoAlimentos { get; set; }
    }
}
