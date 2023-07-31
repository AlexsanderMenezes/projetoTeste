using ValidationResult = Application1.Utils.Objeto.ValidationResult;

namespace Application1.Validators.Utils
{
    public interface IUtilsValidator
    {
         ValidationResult ValidarCep(string cep);
    }
}