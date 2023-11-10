using System;
using Infraestrutura.Enum;

namespace Infraestrutura.Entity
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = null;
        public string Email { get; set; } = null;
        public string Cpf { get; set; } = null;
        public string Telefone { get; set; }
        public string Senha { get; set; } = null;
        public bool PerfilAdministrador { get; set; } = false;
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        public DateTime? DataNascimento { get; set; }

        #region Relacionamento

        //public virtual IEnumerable<SkillUsuario> LSkillUsuarios { get; set; } = null;
        //public virtual Usuario UsuarioFk { get; set; } = null;

        #endregion
    }
}