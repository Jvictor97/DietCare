using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class ClasseAlimentarService : ServiceBase<ClasseAlimentar>, IClasseAlimentarService
    {
        public ClasseAlimentarService(IRepositoryBase<ClasseAlimentar> repository) : base(repository)
        {
        }
    }
}
