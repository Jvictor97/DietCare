using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DietCareDDD.MVC.ViewModels
{
    public class UnidadeViewModel
    {
        [Key]
        public int id_unid { get; set; }

        [Required(ErrorMessage = "Escolha um Símbolo para essa Unidade")]
        [DisplayName("Símbolo")]
        public string unid_simbolo { get; set; }

        [Required(ErrorMessage = "Digite um Nome para essa Unidade")]
        [DisplayName("Descrição")]
        public string unid_descricao { get; set; }
    }
}