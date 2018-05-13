using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Application
{
    public class MetaAppService : AppServiceBase<Meta>, IMetaAppService
    {
        public MetaAppService(IServiceBase<Meta> serviceBase) : base(serviceBase)
        {
        }
    }
}
