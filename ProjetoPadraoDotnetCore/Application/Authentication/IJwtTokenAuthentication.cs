namespace Application.Authentication
{
    public interface IJwtTokenAuthentication
    {
         object GerarToken(string cpf);
    }
}