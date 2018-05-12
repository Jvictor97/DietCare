using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class RefeicaoAlimentoViewModel
    {
        [Key]
        public int id_ref_alimento { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Digite uma Quantidade")]
        public float ref_alimento_quantidade { get; set; }

        [DisplayName("Calorias")]
        [Editable(false)]
        public float ref_alimento_calorias { get; set; }

        [DisplayName("Carboidratos")]
        [Editable(false)]
        public float ref_alimento_carboidratos { get; set; }

        [DisplayName("Proteínas")]
        [Editable(false)]
        public float ref_alimento_proteinas { get; set; }

        [DisplayName("Gorduras")]
        [Editable(false)]
        public float ref_alimento_gorduras { get; set; }

        // Relacionamentos:
        [DisplayName("Refeicao")]
        [Editable(false)]
        public int id_ref { get; set; }
        public virtual RefeicaoViewModel Refeicao { get; set; }

        [DisplayName("Alimento")]
        [Required(ErrorMessage = "Escolha um Alimento")]
        public int id_alimento { get; set; }
        public virtual AlimentoViewModel Alimento { get; set; }

        [DisplayName("Unidade")]
        [Required(ErrorMessage = "Digite uma Unidade")]
        public int id_unid { get; set; }
        public virtual UnidadeViewModel Unidade { get; set; }
    }
}