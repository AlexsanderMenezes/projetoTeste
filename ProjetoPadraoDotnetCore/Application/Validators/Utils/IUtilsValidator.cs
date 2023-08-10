using ValidationResult = Application.Utils.Objeto.ValidationResult;

namespace Application.Validators.Utils
{
    public interface IUtilsValidator
    {
         Application.Utils.Objeto.ValidationResult ValidarCep(string cep);
    }
}