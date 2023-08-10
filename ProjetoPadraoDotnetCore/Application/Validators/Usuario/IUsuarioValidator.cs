using Application.Models.Request.Usuario;
using ValidationResult = Application.Utils.Objeto.ValidationResult;

namespace Application.Validators.Usuario
{
    public interface IUsuarioValidator
    {
         Application.Utils.Objeto.ValidationResult ValidacaoCadastroInicial(UsuarioRegistroInicialRequest request);
         Application.Utils.Objeto.ValidationResult ValidacaoCadastro(UsuarioRequest request);
    }
}