using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DietCareDDD.Domain.Entities
{
    public class Usuario
    {
        public int id_usu { get; set; }

        public string usu_login { get; set; }

        public string usu_senha { get; set; }

        public string usu_nome { get; set; }

        public string usu_email { get; set; }

        // Relacionamentos:
        // Dados Fisicos, Metas, Classes Alimentares, Restricoes
        public int id_dados { get; set; }
        public virtual DadosFisicos DadosFisicos { get; set; }

        public int id_meta { get; set; }
        public virtual Meta Meta { get; set; }

        public int id_classe { get; set; }
        public virtual ClasseAlimentar ClasseAlimentar { get; set; }

        public virtual List<Restricao> Restricoes { get; set; }

        public virtual List<Diario> Diarios { get; set; }
    }
}
