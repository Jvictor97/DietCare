using DietCareDDD.Application.Interface;
using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Application
{
    public class ClasseAlimentarAppService : AppServiceBase<ClasseAlimentar>, IClasseAlimentarAppService
    {
        public ClasseAlimentarAppService(IServiceBase<ClasseAlimentar> serviceBase) : base(serviceBase)
        {
        }
    }
}
