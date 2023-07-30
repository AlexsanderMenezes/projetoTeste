using System.Collections.Generic;
using Aplication.Models.Grid;
using Aplication.Models.Request.Senha;
using Aplication.Models.Request.Usuario;
using Aplication.Models.Response.Usuario;
using Aplication.Utils.Objeto;
using Infraestrutura.Entity;

namespace Application1.Interfaces
{
    public interface IUsuarioApp
    {
         List<Usuario> GetAll();
         Usuario GetByCpf(string cpf);
         Usuario GetByCpfEmail(string cpf, string email);
         UsuarioCrudResponse GetById(int id);
         ValidationResult Cadastrar(UsuarioRequest request);
         ValidationResult Editar(UsuarioRequest request);
         void DeleteById(int id);
         BaseGridResponse ConsultarGridUsuario(BaseGridRequest request);
         ValidationResult AlterarSenha(UsuarioAlterarSenhaRequest request);
         Usuario GetById(int? id);

    }
}