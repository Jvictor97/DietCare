using System.Collections.Generic;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Domain.Interfaces.Services
{
    public interface IAlimentoService : IServiceBase<Alimento>
    {
        IEnumerable<Alimento> BuscaPorNome(string nome);
    }
}
