using System.Collections.Generic;
using System.Linq;
using Infraestrutura.Entity;

namespace Domain2.Interfaces
{
    public interface IUsuarioService
    {
         Usuario GetById(int id);
         Usuario GetByCpf(string cpf);
         List<Usuario> GetAllList();
         IQueryable<Usuario> GetAllQuery();
         void Cadastrar(Usuario usuarioEntity);
         Usuario CadastrarComRetorno(Usuario usuarioEntity);
         void Editar(Usuario usuario);
         void DeleteById(int id);
         Usuario GetByIdWithInclude(int id);
    }
}