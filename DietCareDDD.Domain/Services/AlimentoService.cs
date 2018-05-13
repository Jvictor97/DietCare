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

    }
}
