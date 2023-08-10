using System.Collections.Generic;
using Application.Models.Grid;
using Application.Models.Request.Senha;
using Application.Models.Request.Usuario;
using Application.Utils.Objeto;
using Application.Models.Response.Usuario;
using Infraestrutura.Entity;

namespace Application.Interfaces
{
    public interface IUsuarioApp
    {
         List<Usuario> GetAll();
         Usuario GetByCpf(string cpf);
         Usuario GetByCpfEmail(string cpf, string email);
         Usuario GetById(int id);
         ValidationResult Cadastrar(UsuarioRequest request);
         ValidationResult Editar(UsuarioRequest request);
         void DeleteById(int id);
         BaseGridResponse ConsultarGridUsuario(BaseGridRequest request);
         ValidationResult AlterarSenha(UsuarioAlterarSenhaRequest request);
         Usuario GetById(int? id);

    }
}