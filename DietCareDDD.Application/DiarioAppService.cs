using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Application
{
    public class DiarioAppService : AppServiceBase<Diario>, IDiarioAppService
    {
        public DiarioAppService(IServiceBase<Diario> serviceBase) : base(serviceBase)
        {
        }
    }
}
