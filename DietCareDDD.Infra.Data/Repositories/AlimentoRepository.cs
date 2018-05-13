using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces;

namespace DietCareDDD.Infra.Data.Repositories
{
    public class AlimentoRepository : RepositoryBase<Alimento>, IAlimentoRepository
    {
        public List<Alimento> BuscaPorNome(string nome)
        {
            return Db.Alimentos.Where(a => a.alimento_nome.ToUpper().Contains(nome.ToUpper())).ToList();
        }
    }
}
