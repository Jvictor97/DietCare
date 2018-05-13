using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class DadosFisicosService : ServiceBase<DadosFisicos>, IDadosFisicosService
    {
        public DadosFisicosService(IRepositoryBase<DadosFisicos> repository) : base(repository)
        {
        }
    }
}
