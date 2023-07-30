﻿using Aplication.Models.Request.Usuario;
using Aplication.Models.Response.Usuario;
using Aplication.Utils.HashCripytograph;
using AutoMapper;
using Domain.DTO.Correios;
using Infraestrutura.Entity;

namespace Application1.AutoMapper
{
    public class Mapping : Profile
    {
        protected override void Configure()
        {
            #region Usuario

            CreateMap<SkillRequest, SkillUsuario>()
                .ForMember(dst => dst.Descricao,
                    map => map.MapFrom(src => src.Descricao))
                .ReverseMap();

            CreateMap<UsuarioRequest, Usuario>();
            
            CreateMap<Usuario, UsuarioCrudResponse>()
                .ForMember(dst => dst.DataNascimento,
                    map => map.MapFrom(src => src.DataNascimento.Value.ToString("MM/dd/yyyy")))
                
                .ForMember(dst => dst.Genero,
                    map => map.MapFrom(src => src.Genero.GetHashCode().ToString()))
                .ForMember(dst => dst.Senha,
                    map => map.MapFrom(src => string.Empty));

            CreateMap<UsuarioRegistroInicialRequest, Usuario>()
                .ForMember(dst => dst.Senha,
                    map => map.MapFrom(src => new HashCripytograph().Hash(src.Senha)));


            #endregion


            #region Utils

            CreateMap<EnderecoExternalReponse, EnderecoResponse>()
                .ForMember(dst => dst.Bairro,
                    map => map.MapFrom(src => src.bairro))
                .ForMember(dst => dst.Cidade,
                    map => map.MapFrom(src => src.localidade))
                .ForMember(dst => dst.Estado,
                    map => map.MapFrom(src => src.uf))
                .ForMember(dst => dst.Rua,
                    map => map.MapFrom(src => src.logradouro));

            #endregion
        }
    }
}