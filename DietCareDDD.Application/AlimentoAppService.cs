using System.Collections.Generic;
using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Application
{
    public class AlimentoAppService : AppServiceBase<Alimento>, IAlimentoAppService
    {
        private readonly IAlimentoService _alimentoService;

        public AlimentoAppService(IAlimentoService serviceBase, IAlimentoService alimentoService) 
            : base(serviceBase)
        {
            _alimentoService = alimentoService;
        }

        public IEnumerable<Alimento> BuscaPorNome(string nome)
        {
            return _alimentoService.BuscaPorNome(nome);
        }
    }
}
