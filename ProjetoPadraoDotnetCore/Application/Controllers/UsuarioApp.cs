

using System;
using System.Collections.Generic;
using System.Linq;
using Application.Authentication;
using Application.Interfaces;
using Application.Models.Grid;
using Application.Models.Request.Senha;
using Application.Models.Request.Usuario;
using Application.Models.Response.Usuario;
using Application.Utils.HashCripytograph;
using Application.Utils.Objeto;
using Application.Validators.Usuario;
using Application.Utils.FilterDynamic;
using Application.Utils.Helpers;
using AutoMapper;
using Domain2.Interfaces;
using Infraestrutura.Entity;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Application.Controllers
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

        public Usuario GetById(int id)
        {
            return Service.GetByIdWithInclude(id);
        }

        public ValidationResult Cadastrar(UsuarioRequest request)
        {
            var validation = Validation.ValidacaoCadastro(request);
            var lUsuario = Service.GetAllList();

            if (lUsuario.Any(x => x.Email == request.Email))
                validation.LErrors.Add("Email já vinculado a outro usuário");

            if (validation.IsValid())
            {

                var usuario = Mapper.Map<Usuario>(request);

                //Hash da senha
                usuario.Senha = new HashCripytograph().Hash(request.Senha);
                var cadastro = Service.CadastrarComRetorno(usuario);

            }

            return validation;
        }
        
        public ValidationResult CadastroInicial(UsuarioRegistroInicialRequest request)
        {
            var validation = Validation.ValidacaoCadastroInicial(request);
            var lUsuario = Service.GetAllList();

            if (lUsuario.Any(x => x.Email == request.Email))
                validation.LErrors.Add("Email já vinculado a outro usuário");

            if (validation.IsValid())
            {
                //Ajustar mapper, atualizar o dotnet para versao 6
                var usuario = new Usuario();

                usuario.Bairro = "";
                usuario.Cep = "";
                usuario.Cidade = "";
                usuario.Estado = "";
                usuario.Rua = "";
                usuario.Telefone = "";
                usuario.Numero = 0;
                usuario.DataNascimento = new DateTime();
                usuario.Cpf = request.CPF;
                usuario.Email = request.Email;
                usuario.Nome = request.Nome;

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
            var usuarioOld = lUsuario.FirstOrDefault(x => x.IdUsuario == request.IdUsuario);

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


        public BaseGridResponse ConsultarGridUsuario()
        {
            var itens = Service.GetAllQuery();
            
            return new BaseGridResponse()
            {
                Itens = itens.Select(x => new UsuarioGridResponse()
                    {
                        IdUsuario = x.IdUsuario,
                        Nome = x.Nome,
                        Cpf = x.Cpf.ToFormatCpf(),
                        Telefone = x.Telefone.FormatTelefone()
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