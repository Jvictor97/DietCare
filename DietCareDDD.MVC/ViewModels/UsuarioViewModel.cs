using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int id_usu { get; set; }

        [DisplayName("Login")]
        [Required(ErrorMessage = "Digite um Login")]
        public string usu_login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Digite uma Senha")]
        [DataType(DataType.Password)]
        public string usu_senha { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite um Nome")]
        public string usu_nome { get; set; }

        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "Digite um E-Mail")]
        public string usu_email { get; set; }

        // Relacionamentos:
        // Dados Fisicos, Metas, Classes Alimentares, Restricoes
        [ScaffoldColumn(false)]
        public int id_dados { get; set; }
        public virtual DadosFisicosViewModel DadosFisicos { get; set; }

        [ScaffoldColumn(false)]
        public int id_meta { get; set; }
        public virtual MetaViewModel Meta { get; set; }

        [ScaffoldColumn(false)]
        public int id_classe { get; set; }
        public virtual ClasseAlimentarViewModel ClasseAlimentar { get; set; }

        [ScaffoldColumn(false)]
        public virtual List<RestricaoViewModel> Restricoes { get; set; }

        [ScaffoldColumn(false)]
        public virtual List<DiarioViewModel> Diarios { get; set; }
    }
}