using System.Collections.Generic;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class AlimentoService : ServiceBase<Alimento>, IAlimentoService
    {
        public AlimentoService(IAlimentoRepository alimentoRepository) 
            : base(alimentoRepository)
        {
            _alimentoRepository = alimentoRepository;
        }
        private readonly IAlimentoRepository _alimentoRepository;

        public IEnumerable<Alimento> BuscaPorNome(string nome)
        {
            return _alimentoRepository.BuscaPorNome(nome);
        }

        // Caso haja algum método que interage com as entidades na tabela
        // Executar a chamada aqui
        // Exemplo no Vídeo:
        /*
         *  public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
         *  {
         *      return clientes.Where(c => c.ClienteEspecial(c));
         *  }
         */
         // Obs: o método ClienteEspecial retorna bool e foi declarado na classe Cliente
    }
}
