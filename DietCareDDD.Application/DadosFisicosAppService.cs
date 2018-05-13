using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Application
{
    public class DadosFisicosAppService : AppServiceBase<DadosFisicos>, IDadosFisicosAppService
    {
        public DadosFisicosAppService(IServiceBase<DadosFisicos> serviceBase) : base(serviceBase)
        {
        }
    }
}
