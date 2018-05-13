using System.Collections.Generic;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Domain.Interfaces.Repositories
{
    public interface IAlimentoRepository : IRepositoryBase<Alimento>
    {
        IEnumerable<Alimento> BuscaPorNome(string nome);
    }
}
