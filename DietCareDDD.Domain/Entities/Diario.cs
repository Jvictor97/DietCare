using System;
using System.Collections.Generic;

namespace DietCareDDD.Domain.Entities
{
    public class Diario
    {
        public int id_diario { get; set; }

        public DateTime diario_dia { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual List<Refeicao> Refeicoes { get; set; }
    }
}
