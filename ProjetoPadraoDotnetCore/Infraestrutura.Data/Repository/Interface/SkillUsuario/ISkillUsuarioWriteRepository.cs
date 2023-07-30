using Infraestrutura.Repository.Interface.Base;

namespace Infraestrutura.Repository.Interface.SkillUsuario
{
    public interface ISkillUsuarioWriteRepository : IBaseWriteRepository<Entity.SkillUsuario>
    { 
        void RemoveSkillByUsuario(int id);
    }
}