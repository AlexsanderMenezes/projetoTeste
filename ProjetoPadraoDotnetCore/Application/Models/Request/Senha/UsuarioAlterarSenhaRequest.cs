﻿namespace Application.Models.Request.Senha
{
    public class UsuarioAlterarSenhaRequest
    {
        public int IdUsuario { get; set; }
        public string Senha { get; set; }
    }
}