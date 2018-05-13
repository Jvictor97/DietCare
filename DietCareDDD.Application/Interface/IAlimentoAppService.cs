using System.Collections.Generic;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Application.Interface
{
    public interface IAlimentoAppService : IAppServiceBase<Alimento>
    {
        IEnumerable<Alimento> BuscaPorNome(string nome);
        // Inserir protótipo de métodos implementados no AlimentoService
    }
}
