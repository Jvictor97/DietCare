using System.Collections.Generic;
using System.Linq;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;

namespace DietCareDDD.Infra.Data.Repositories
{
    public class AlimentoRepository : RepositoryBase<Alimento>, IAlimentoRepository
    {
        public IEnumerable<Alimento> BuscaPorNome(string nome)
        {
            return Db.Alimentos.Where(a => a.alimento_nome.ToUpper().Contains(nome.ToUpper()));
        }
    }
}
