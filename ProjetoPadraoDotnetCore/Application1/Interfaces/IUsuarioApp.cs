using System.Collections.Generic;
using Application1.Models.Grid;
using Application1.Models.Request.Senha;
using Application1.Models.Request.Usuario;
using Application1.Models.Response.Usuario;
using Application1.Utils.Objeto;
using Infraestrutura.Entity;

namespace Application1.Interfaces
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