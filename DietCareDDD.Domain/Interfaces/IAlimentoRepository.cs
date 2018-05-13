using System;
using System.Collections.Generic;
using DietCareDDD.Domain.Entities;

namespace DietCareDDD.Domain.Interfaces
{
    public interface IAlimentoRepository : IRepositoryBase<Alimento>
    {
        List<Alimento> BuscaPorNome(string nome);
    }
}
