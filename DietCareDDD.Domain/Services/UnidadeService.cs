using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class UnidadeService : ServiceBase<Unidade>, IUnidadeService
    {
        public UnidadeService(IRepositoryBase<Unidade> repository) : base(repository)
        {
        }
    }
}
