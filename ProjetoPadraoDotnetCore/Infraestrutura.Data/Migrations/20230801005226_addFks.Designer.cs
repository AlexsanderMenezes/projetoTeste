﻿// <auto-generated />
using System;
using Infraestrutura.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestrutura.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230801005226_addFks")]
    partial class addFks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infraestrutura.Entity.SkillUsuario", b =>
                {
                    b.Property<int>("IdSkill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdSkill");

                    b.HasIndex("IdUsuario");

                    b.ToTable("SkillUsuario");
                });

            modelBuilder.Entity("Infraestrutura.Entity.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnName("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnName("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnName("Cidade1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CodigoRecuperarSenha")
                        .HasColumnName("CodigoRecuperarSenha")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnName("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRecuperacaoSenha")
                        .HasColumnName("DataRecuperacaoSenha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .HasColumnName("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnName("Genero")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioCadastro")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeMae")
                        .HasColumnName("NomeMae")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePai")
                        .HasColumnName("NomePai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Numero")
                        .HasColumnName("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnName("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnName("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PerfilAdministrador")
                        .HasColumnName("PerfilAdministrador")
                        .HasColumnType("bit");

                    b.Property<string>("Rua")
                        .HasColumnName("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnName("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TentativasRecuperarSenha")
                        .HasColumnName("TentativasRecuperarSenha")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdUsuarioCadastro");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Infraestrutura.Entity.SkillUsuario", b =>
                {
                    b.HasOne("Infraestrutura.Entity.Usuario", "Usuario")
                        .WithMany("LSkillUsuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infraestrutura.Entity.Usuario", b =>
                {
                    b.HasOne("Infraestrutura.Entity.Usuario", "UsuarioFk")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCadastro");
                });
#pragma warning restore 612, 618
        }
    }
}
