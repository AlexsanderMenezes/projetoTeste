using System.Collections.Generic;
using System.Linq;
using Domain2.Interfaces;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.SkillUsuario;
using Infraestrutura.Repository.Interface.Usuario;

namespace Domain2.Services
{
    public class UsuarioService : IUsuarioService
    {
        protected readonly IUsuarioReadRepository ReadRepository;
        protected readonly IUsuarioWriteRepository WriteRepository;
        protected readonly ISkillUsuarioWriteRepository SkillWriteRepository;

        public UsuarioService(IUsuarioReadRepository readRepository, IUsuarioWriteRepository writeRepository,
            ISkillUsuarioWriteRepository skillWriteRepository)
        {
            ReadRepository = readRepository;
            WriteRepository = writeRepository;
            SkillWriteRepository = skillWriteRepository;
        }

        public Usuario GetByIdWithInclude(int id)
        {
            return ReadRepository.GetByIdWithInclude(id);
        }

        public Usuario GetById(int id)
        {
            return ReadRepository.GetById(id);
        }

        public Usuario GetByCpf(string cpf)
        {
            return ReadRepository.GetAll().FirstOrDefault(x => x.Cpf == cpf);
        }

        public List<Usuario> GetAllList()
        {
            return ReadRepository.GetAll().ToList();
        }

        public IQueryable<Usuario> GetAllQuery()
        {
            return ReadRepository.GetAll();
        }

        public void Cadastrar(Usuario usuario)
        {
            WriteRepository.Add(usuario);
        }

        public Usuario CadastrarComRetorno(Usuario usuario)
        {
            return WriteRepository.AddWithReturn(usuario);
        }

        public void Editar(Usuario usuario)
        {
           // SkillWriteRepository.RemoveSkillByUsuario(usuario.IdUsuario);
            WriteRepository.Update(usuario);
        }

        public void DeleteById(int id)
        {
            WriteRepository.DeleteById(id);
        }
    }
}