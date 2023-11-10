using Application.Models.Request.Usuario;
using ValidationResult = Application.Utils.Objeto.ValidationResult;

namespace Application.Validators.Usuario
{
    public interface IUsuarioValidator
    {
         ValidationResult ValidacaoCadastroInicial(UsuarioRegistroInicialRequest request);
         ValidationResult ValidacaoCadastro(UsuarioRequest request);
    }
}