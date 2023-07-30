using System.Threading.Tasks;
using Infraestrutura.Repository.External.Response;

namespace Infraestrutura.Repository.External
{

    public interface IExternalRepository
    {
         Task<BaseResponseExternal> SendWebHttp(string url);
    }
}