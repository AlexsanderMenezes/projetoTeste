using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Aplication.Authentication
{
    public class JwtAuthentication : IJwtTokenAuthentication
    {
        public object GerarToken(string cpf)
        {
            //Gera o TOken atraves do CPF encriptado
            var claims = new List<Claim>
            {
                new Claim("CPF", cpf.Trim())
            };

            //tempo para expirar o token
            var expires = DateTime.Now.AddHours(5);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ProjetoPadraoDotnet6"));
            var tokenData = new JwtSecurityToken(
                //tipo de criptografia
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                acess_token = token,
                expiration = expires
            };
        }
    }
}