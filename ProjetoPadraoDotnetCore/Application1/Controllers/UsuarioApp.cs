

using System.Collections.Generic;
using System.Linq;
using Application1.Authentication;
using Application1.Interfaces;
using Application1.Models.Grid;
using Application1.Models.Request.Senha;
using Application1.Models.Request.Usuario;
using Application1.Models.Response.Usuario;
using Application1.Utils.FilterDynamic;
using Application1.Utils.HashCripytograph;
using Application1.Utils.Helpers;
using Application1.Utils.Objeto;
using Application1.Validators.Usuario;
using AutoMapper;
using Domain2.Interfaces;
using Infraestrutura.Entity;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Application1.Controllers
{
    public class UsuarioApp : IUsuarioApp
    {
        protected readonly IUsuarioService Service;
        protected readonly IMapper Mapper;
        protected readonly IUsuarioValidator Validation;
        protected readonly IJwtTokenAuthentication Jwt;
        private readonly IConfiguration _configuration;

        public UsuarioApp(IUsuarioService service, IMapper mapper, IUsuarioValidator validation,
            IJwtTokenAuthentication jwt, IConfiguration configuration)
        {
            Service = service;
            Mapper = mapper;
            Validation = validation;
            Jwt = jwt;
            _configuration = configuration;
        }

        public List<Usuario> GetAll()
        {
            return Service.GetAllList();
        }

        public Usuario GetByCpf(string cpf)
        {
            return Service.GetByCpf(cpf);
        }

        public Usuario GetByCpfEmail(string cpf, string email)
        {
            return Service.GetAllQuery().FirstOrDefault(x => x.Email == email && x.Cpf == cpf);
        }

        public UsuarioCrudResponse GetById(int id)
        {
            return Mapper.Map<Usuario, UsuarioCrudResponse>(Service.GetByIdWithInclude(id));
        }

        public ValidationResult Cadastrar(UsuarioRequest request)
        {
            var validation = Validation.ValidacaoCadastro(request);
            var lUsuario = Service.GetAllList();

            if (lUsuario.Any(x => x.Email == request.Email))
                validation.LErrors.Add("Email já vinculado a outro usuário");

            if (validation.IsValid())
            {
                var usuario = Mapper.Map<UsuarioRequest, Usuario>(request);

                //Hash da senha
                usuario.Senha = new HashCripytograph().Hash(request.Senha);
                var cadastro = Service.CadastrarComRetorno(usuario);

            }

            return validation;
        }


        public ValidationResult Editar(UsuarioRequest request)
        {
            var validation = Validation.ValidacaoCadastro(request);
            var lUsuario = Service.GetAllQuery();
            var usuarioOld = Service.GetById(request.IdUsuario ?? 0);

            if (lUsuario.Any(x => x.Email == request.Email && x.IdUsuario != request.IdUsuario))
                validation.LErrors.Add("Email já vinculado a outro usuário");

            if (validation.IsValid())
            {
                var usuario = Mapper.Map<UsuarioRequest, Usuario>(request);

                if (string.IsNullOrEmpty(request.Senha) && usuarioOld != null)
                    usuario.Senha = usuarioOld.Senha;

                Service.Editar(usuario);
            }

            return validation;
        }

        public void DeleteById(int id)
        {
            Service.DeleteById(id);
        }


        public BaseGridResponse ConsultarGridUsuario(BaseGridRequest request)
        {
            var itens = Service.GetAllQuery();
            
            itens = itens.AplicarFiltrosDinamicos(request.QueryFilters);

            return new BaseGridResponse()
            {
                Itens = itens.Skip(request.Page * request.Take).Take(request.Take)
                    .Select(x => new UsuarioGridResponse()
                    {
                        IdUsuario = x.IdUsuario,
                        Nome = x.Nome,
                        Cpf = x.Cpf.ToFormatCpf(),
                        DataNascimento = x.DataNascimento == null ? null : x.DataNascimento.Value.FormatDateBr(),
                        Email = x.Email,
                        Senha = x.Senha,
                        Telefone = x.Telefone,
                        Perfil = x.PerfilAdministrador ? "Administrador" : "Comum"
                    }).ToList(),

                TotalItens = itens.Count()
            };
        }

        public ValidationResult AlterarSenha(UsuarioAlterarSenhaRequest request)
        {
            var retorno = new ValidationResult();

            var usuario = Service.GetById(request.IdUsuario);

            if (usuario == null)
                retorno.LErrors.Add("Usuário não encontrado na base!");

            if (retorno.IsValid() && usuario != null)
            {
                usuario.Senha = new HashCripytograph().Hash(request.Senha);
                usuario.TentativasRecuperarSenha = 0;
                Service.Editar(usuario);
            }

            return retorno;
        }

        public Usuario GetById(int? id)
        {
            return Service.GetById(id ?? 0);
        }

    }

}