using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class RefeicaoViewModel
    {
        [Key]
        public int id_ref { get; set; }

        [DisplayName("Nome da Refeição")]
        [Required(ErrorMessage = "Digite um Nome")]
        public string ref_nome { get; set; }

        //Relacionamentos:
        [ScaffoldColumn(false)]
        public int id_diario { get; set; }
        public virtual DiarioViewModel Diario { get; set; }

        [DisplayName("Alimentos da Refeição")]
        public virtual List<RefeicaoAlimentoViewModel> RefeicaoAlimentos { get; set; }
    }
}