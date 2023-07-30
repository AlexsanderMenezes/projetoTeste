using Infraestrutura.Repository.Interface.Base;

namespace Infraestrutura.Repository.Interface.Usuario
{

    public interface IUsuarioReadRepository : IBaseReadRepository<Entity.Usuario>
    {
         Entity.Usuario GetByIdWithInclude(int id);

    }
}