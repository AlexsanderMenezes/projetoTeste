namespace Aplication.Authentication
{
    public interface IJwtTokenAuthentication
    {
         object GerarToken(string cpf);
    }
}