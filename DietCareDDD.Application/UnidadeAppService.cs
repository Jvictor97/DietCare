using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Application
{
    public class UnidadeAppService : AppServiceBase<Unidade>, IUnidadeAppService
    {
        public UnidadeAppService(IServiceBase<Unidade> serviceBase) : base(serviceBase)
        {
        }
    }
}
