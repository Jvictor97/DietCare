using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces.Repositories;
using DietCareDDD.Domain.Interfaces.Services;

namespace DietCareDDD.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        public UsuarioService(IRepositoryBase<Usuario> repository) : base(repository)
        {
        }
    }
}
