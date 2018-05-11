using System;
using System.Collections.Generic;

namespace DietCareDDD.MVC.ViewModels
{
    public class DiarioViewModel
    {
        public int id_diario { get; set; }

        public DateTime diario_dia { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual List<RefeicaoViewModel> Refeicoes { get; set; }
    }
}