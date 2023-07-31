using Application1.Models.Request.Usuario;
using ValidationResult = Application1.Utils.Objeto.ValidationResult;

namespace Application1.Validators.Usuario
{
    public interface IUsuarioValidator
    {
         ValidationResult ValidacaoCadastroInicial(UsuarioRegistroInicialRequest request);
         ValidationResult ValidacaoCadastro(UsuarioRequest request);
    }
}