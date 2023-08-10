using Application.Utils.Objeto;

namespace Application.Validators.Utils
{
    public class UtilsValidatior : IUtilsValidator
    {
        public ValidationResult ValidarCep(string cep)
        {
            var validation = new ValidationResult();

            if (string.IsNullOrEmpty(cep))
                validation.LErrors.Add("Campo cep é obrigatório!");
            if (cep.Length < 8)
                validation.LErrors.Add("Campo cep inválido!");

            return validation;
        }
    }
}