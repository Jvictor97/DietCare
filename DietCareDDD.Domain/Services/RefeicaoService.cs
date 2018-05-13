using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class RefeicaoService : ServiceBase<Refeicao>, IRefeicaoService
    {
        public RefeicaoService(IRepositoryBase<Refeicao> repository) : base(repository)
        {
        }
    }
}
