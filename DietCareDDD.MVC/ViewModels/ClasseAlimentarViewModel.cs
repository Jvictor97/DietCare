using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class ClasseAlimentarViewModel
    {
        [Required(ErrorMessage = "Digite uma Valor (e.g.: 'Sem Classe', 'Vegetariano', 'Vegano')")]
        [DisplayName("Tipo de Classe")]
        public string classe_tipo { get; set; }

        // Relacionamentos:
        [Key]
        [DisplayName("Usuário")]
        public int id_usu { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}