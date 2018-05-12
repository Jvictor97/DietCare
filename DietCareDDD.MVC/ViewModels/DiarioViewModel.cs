using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class DiarioViewModel
    {
        [Key]
        public int id_diario { get; set; }

        [ScaffoldColumn(false)]
        public DateTime diario_dia { get; set; } = DateTime.Now;

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }

        public virtual List<RefeicaoViewModel> Refeicoes { get; set; }
    }
}