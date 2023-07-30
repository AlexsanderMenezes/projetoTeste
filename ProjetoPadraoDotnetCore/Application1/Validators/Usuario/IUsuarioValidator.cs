using Aplication.Models.Request.Usuario;
using ValidationResult = Aplication.Utils.Objeto.ValidationResult;

namespace Aplication.Validators.Usuario
{
    public interface IUsuarioValidator
    {
         ValidationResult ValidacaoCadastroInicial(UsuarioRegistroInicialRequest request);
         ValidationResult ValidacaoCadastro(UsuarioRequest request);
    }
}