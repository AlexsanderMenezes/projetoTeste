﻿using System.Collections.Generic;
using Application.Models.Request.Usuario;

namespace Application.Models.Response.Usuario
{
    public class UsuarioCrudResponse
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = null;
        public string Email { get; set; } = null;
        public string Cpf { get; set; } = null;
        public string Telefone { get; set; }
        public string Senha { get; set; } = null;
        public bool PerfilAdministrador { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        public string DataNascimento { get; set; } = null;

        public List<SkillRequest> lSkills { get; set; } = null;
    }
}