namespace Application1.Authentication
{
    public interface IJwtTokenAuthentication
    {
         object GerarToken(string cpf);
    }
}