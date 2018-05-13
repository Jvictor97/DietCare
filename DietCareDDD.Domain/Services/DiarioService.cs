using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class DiarioService : ServiceBase<Diario>, IDiarioService
    {
        public DiarioService(IRepositoryBase<Diario> repository) : base(repository)
        {
        }
    }
}
