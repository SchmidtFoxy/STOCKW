﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using STOCKW.Data;

#nullable disable

namespace STOCKW.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20240901000241_NomeDaNovaMigracao")]
    partial class NomeDaNovaMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("STOCKW.Models.Dominio.Cidade", b =>
                {
                    b.Property<int>("ID_Cidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Cidade"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Cidade");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Item", b =>
                {
                    b.Property<int>("ID_Item")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Item"));

                    b.Property<string>("Caracteristica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimensao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("ID_Item");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Movimentacao", b =>
                {
                    b.Property<int>("ID_Movimentacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Movimentacao"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Entidade")
                        .HasColumnType("int");

                    b.Property<int>("ID_Item")
                        .HasColumnType("int");

                    b.Property<int>("ID_TipoMovimentacao")
                        .HasColumnType("int");

                    b.Property<int>("ID_Usuario")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeMovimentada")
                        .HasColumnType("int");

                    b.HasKey("ID_Movimentacao");

                    b.HasIndex("ID_Entidade");

                    b.HasIndex("ID_Item");

                    b.HasIndex("ID_TipoMovimentacao");

                    b.HasIndex("ID_Usuario");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Pessoa", b =>
                {
                    b.Property<int>("ID_Pessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Pessoa"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("ID_Cidade")
                        .HasColumnType("int");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Pessoa");

                    b.HasIndex("ID_Cidade");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator().HasValue("Pessoa");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.TipoMovimentacao", b =>
                {
                    b.Property<int>("ID_TipoMovimentacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_TipoMovimentacao"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_TipoMovimentacao");

                    b.ToTable("TiposMovimentacao");
                });

            modelBuilder.Entity("STOCKW.Models.Identidade.Permissao", b =>
                {
                    b.Property<int>("ID_Permissao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Permissao"));

                    b.Property<string>("GrupoPermissao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Permissao");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("STOCKW.Models.Identidade.Usuario", b =>
                {
                    b.Property<int>("ID_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Usuario"));

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_Permissao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Usuario");

                    b.HasIndex("ID_Permissao");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Fisica", b =>
                {
                    b.HasBaseType("STOCKW.Models.Dominio.Pessoa");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Fisica");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Juridica", b =>
                {
                    b.HasBaseType("STOCKW.Models.Dominio.Pessoa");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InscricaoMunicipal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Juridica");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Movimentacao", b =>
                {
                    b.HasOne("STOCKW.Models.Dominio.Pessoa", "Entidade")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ID_Entidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("STOCKW.Models.Dominio.Item", "Item")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ID_Item")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("STOCKW.Models.Dominio.TipoMovimentacao", "TipoMovimentacao")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ID_TipoMovimentacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("STOCKW.Models.Identidade.Usuario", "Usuario")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ID_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entidade");

                    b.Navigation("Item");

                    b.Navigation("TipoMovimentacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Pessoa", b =>
                {
                    b.HasOne("STOCKW.Models.Dominio.Cidade", "Cidade")
                        .WithMany("Pessoas")
                        .HasForeignKey("ID_Cidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("STOCKW.Models.Identidade.Usuario", b =>
                {
                    b.HasOne("STOCKW.Models.Identidade.Permissao", "Permissao")
                        .WithMany("Usuarios")
                        .HasForeignKey("ID_Permissao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissao");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Cidade", b =>
                {
                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Item", b =>
                {
                    b.Navigation("Movimentacoes");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.Pessoa", b =>
                {
                    b.Navigation("Movimentacoes");
                });

            modelBuilder.Entity("STOCKW.Models.Dominio.TipoMovimentacao", b =>
                {
                    b.Navigation("Movimentacoes");
                });

            modelBuilder.Entity("STOCKW.Models.Identidade.Permissao", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("STOCKW.Models.Identidade.Usuario", b =>
                {
                    b.Navigation("Movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
