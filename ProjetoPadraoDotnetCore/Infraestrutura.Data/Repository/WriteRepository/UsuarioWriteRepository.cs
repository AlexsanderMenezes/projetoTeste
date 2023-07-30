using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Usuario;
using Infraestrutura.Repository.WriteRepository;

namespace Infraestrutura.Repository.WriteRepository
{
    public class UsuarioWriteRepository : BaseWriteRepository<Usuario>, IUsuarioWriteRepository
    {
        public UsuarioWriteRepository(Context context) : base(context)
        {
        }
    }
}