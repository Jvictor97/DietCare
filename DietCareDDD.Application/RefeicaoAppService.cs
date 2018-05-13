using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Application
{
    public class RefeicaoAppService : AppServiceBase<Refeicao>, IRefeicaoAppService
    {
        public RefeicaoAppService(IServiceBase<Refeicao> serviceBase) : base(serviceBase)
        {
        }
    }
}
