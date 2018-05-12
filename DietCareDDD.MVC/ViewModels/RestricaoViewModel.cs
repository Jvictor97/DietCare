using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DietCareDDD.MVC.ViewModels
{
    public class RestricaoViewModel
    {
        [Key]
        public int id_rest { get; set; }

        // Relacionamentos:
        [DisplayName("Usuário")]
        public int id_usu { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }

        [DisplayName("Alimento")]
        [Required(ErrorMessage = "Escolha um Alimento")]
        public int id_alimento { get; set; }
        public virtual AlimentoViewModel Alimento { get; set; }
    }
}