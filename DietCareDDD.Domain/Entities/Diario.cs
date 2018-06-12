/* =============================================
 * Departamento: TI - Desenvolvimento
 * Gerente Responsável: Renato Yamaguti
 * Última Alteração: 09/05/2018
 * Desenvolvedor: João Victor F. Souza
 * Tipo: classe de representação da entidade
 *       Diario.
 * Funcionalidade: criação dos atributos
 *                 pertencentes à entidade,
 *                 para a geração automatizada
 *                 das tabelas no Banco de Dados
 * Modificado por: João Victor F. Souza
 * Justificativa: necessidade de realizar a
 *                normalização do Banco de Dados
 *
 * <<Código em Operação>>
 * Domínio: http://dietcare.azurewebsites.com
 * IP: 192.167.3.5 Máscara: 255.255.255.0
 * ============================================= */
using System;
using System.Collections.Generic;

namespace DietCareDDD.Domain.Entities
{
    public class Diario
    {
        public int id_diario { get; set; }

        public DateTime diario_dia { get; set; }

        // Relacionamentos:
        public int id_usu { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual List<Refeicao> Refeicoes { get; set; }
    }
}
