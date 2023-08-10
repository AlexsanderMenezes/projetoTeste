﻿using System;
using System.Collections.Generic;
using Infraestrutura.Entity;
using Infraestrutura.Enum;

namespace Application.Models.Request.Usuario
{
    public class UsuarioRequest
    {
        public int? IdUsuario { get; set; }
        public string Nome { get; set; } = null;
        public string Foto { get; set; } = null;
        public string Senha { get; set; } = null;
        public string Email { get; set; } = null;
        public bool PerfilAdministrador { get; set; }
        public string Cep { get; set; } = null;
        public string Estado { get; set; } = null;
        public string Cidade { get; set; } = null;
        public string Pais { get; set; } = null;
        public string Rua { get; set; } = null;
        public string Bairro { get; set; } = null;
        public int? Numero { get; set; }
        public string NomeMae { get; set; } = null;
        public string NomePai { get; set; } = null;
        public string Cpf { get; set; } = null;
        public string Observacao { get; set; } = null;
        public string Telefone { get; set; } = null;
        public DateTime? DataNascimento { get; set; }
        public EGenero Genero { get; set; }
        //public List<SkillRequest> lSkills { get; set; }
        
        //
        public int? IdUsuarioCadastro { get; set; }
        public int? CodigoRecuperarSenha { get; set; }
        public int? TentativasRecuperarSenha { get; set; }
        public DateTime? DataRecuperacaoSenha { get; set; }
        
        //public virtual IEnumerable<SkillUsuario> LSkillUsuarios { get; set; } = null;
        //public virtual Infraestrutura.Entity.Usuario UsuarioFk { get; set; } = null;
    }


}