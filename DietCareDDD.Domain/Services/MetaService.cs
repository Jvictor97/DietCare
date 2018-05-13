using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class MetaService : ServiceBase<Meta>, IMetaService
    {
        public MetaService(IRepositoryBase<Meta> repository) : base(repository)
        {
        }
    }
}
