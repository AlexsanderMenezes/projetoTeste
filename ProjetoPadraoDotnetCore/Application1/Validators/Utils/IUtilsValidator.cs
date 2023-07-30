using ValidationResult = Aplication.Utils.Objeto.ValidationResult;

namespace Aplication.Validators.Utils
{
    public interface IUtilsValidator
    {
         ValidationResult ValidarCep(string cep);
    }
}