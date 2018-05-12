using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.MVC.ViewModels
{
    public class MetaViewModel
    {
        [DisplayName("Calorias")]
        [Range(0, 9999, ErrorMessage = "O valor deve estar entre 0 e 9999")]
        [Required(ErrorMessage = "Digite um valor para Calorias")]
        public int meta_calorias { get; set; }

        [DisplayName("Carboidratos")]
        [Required(ErrorMessage = "Digite um valor para Carboidratos")]
        public float meta_carboidratos { get; set; } = 0;

        [DisplayName("Proteínas")]
        [Required(ErrorMessage = "Digite um valor para Proteínas")]
        public float meta_proteinas { get; set; } = 0;

        [DisplayName("Gorduras")]
        [Required(ErrorMessage = "Digite um valor para Gorduras")]
        public float meta_gorduras { get; set; } = 0;

        // Relacionamentos:
        [Key]
        [DisplayName("Usuário")]
        public int id_usu { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}