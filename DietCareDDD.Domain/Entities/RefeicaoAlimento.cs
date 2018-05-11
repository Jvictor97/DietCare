using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietCareDDD.Domain.Entities
{
    public class RefeicaoAlimento
    {
        public int id_ref_alimento { get; set; }

        public float ref_alimento_quantidade { get; set; }

        public float ref_alimento_calorias { get; set; }

        public float  ref_alimento_carboidratos { get; set; }

        public float ref_alimento_proteinas { get; set; }

        public float ref_alimento_gorduras { get; set; }

        // Relacionamentos:
        public int id_ref { get; set; }
        public virtual Refeicao Refeicao { get; set; }

        public int id_alimento { get; set; }
        public virtual Alimento Alimento { get; set; }

        public int id_unid { get; set; }
        public virtual Unidade Unidade { get; set; }
    }
}
