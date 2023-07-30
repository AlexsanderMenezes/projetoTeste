using System.Collections.Generic;

namespace Aplication.Utils.Email
{
     public interface IEmailHelper
     {
          bool EnviarEmail(List<string> email, string titulo, string corpo);
     }
}