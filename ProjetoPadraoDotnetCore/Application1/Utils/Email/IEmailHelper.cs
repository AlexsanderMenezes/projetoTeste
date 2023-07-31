using System.Collections.Generic;

namespace Application1.Utils.Email
{
     public interface IEmailHelper
     {
          bool EnviarEmail(List<string> email, string titulo, string corpo);
     }
}