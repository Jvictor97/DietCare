using DietCareDDD.Domain.Entities;
using DietCareDDD.Domain.Interfaces;
using DietCareDDD.Domain.Interfaces.Repositories;

namespace DietCareDDD.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
    }
}
