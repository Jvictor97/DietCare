using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class AlimentoViewModel
    {
        [Key]
        public int id_alimento { get; set; }

        [Required(ErrorMessage = "Digite um nome")]
        [DisplayName("Nome do Alimento")]
        public string alimento_nome { get; set; }

        [Required(ErrorMessage = "Digite um valor para Calorias")]
        [DisplayName("Calorias")]
        [Range(0, 9999, ErrorMessage = "O valor deve estar entre 0 e 9999")]
        public int alimento_calorias { get; set; }

        [DisplayName("Carboidratos")]
        [Range(0, 9999, ErrorMessage = "O valor deve estar entre 0 e 9999")]
        public float alimento_carboidratos { get; set; }

        [DisplayName("Proteinas")]
        [Range(0, 9999, ErrorMessage = "O valor deve estar entre 0 e 9999")]
        public float alimento_proteinas { get; set; }

        [DisplayName("Gorduras")]
        [Range(0, 9999, ErrorMessage = "O valor deve estar entre 0 e 9999")]
        public float alimento_gorduras { get; set; }

        [DisplayName("Porção Base")]
        [Range(0, 9999, ErrorMessage = "O valor deve estar entre 0 e 9999")]
        public float alimento_porcao_base { get; set; }

        // Relacionamentos:
        [Required(ErrorMessage = "Digite a Unidade Base")]
        [DisplayName("Unidade de Medida")]
        public int id_unid { get; set; }
        public virtual UnidadeViewModel Unidade { get; set; }
    }
}