using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class DadosFisicosViewModel
    {
        [DisplayName("Peso")]
        public float dados_peso { get; set; }

        [DisplayName("Altura em Metros")]
        [Range(1.00, 2.00, ErrorMessage = "Digite uma Altura válida")]
        public float dados_altura { get; set; }

        [DisplayName("Idade")]
        [Range(0, 120, ErrorMessage = "Digite uma Idade válida")]
        public int dados_idade { get; set; }

        // Relacionamentos:
        [Key]
        public int id_usu { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}