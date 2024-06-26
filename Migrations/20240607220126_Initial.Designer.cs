﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using gs_bluehorizon_dotnet.Data;

#nullable disable

namespace gs_bluehorizon_dotnet.Migrations
{
    [DbContext(typeof(BlueHorizonDbContext))]
    [Migration("20240607220126_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.PontosColeta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_ponto");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("EstadoPonto")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR2(2)")
                        .HasColumnName("estado_ponto");

                    b.Property<string>("GerentePonto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("gerente_ponto");

                    b.Property<string>("NomePonto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_ponto");

                    b.HasKey("Id");

                    b.ToTable("pontos_coleta");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.RecebimentoLixo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_recebimento");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("DtRecebimento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dt_recebimento");

                    b.Property<long?>("PerfilId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_perfil");

                    b.Property<long?>("PessoaId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_pessoa");

                    b.Property<long?>("PontosColetaId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_pontosColeta");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("PontosColetaId");

                    b.ToTable("recebimento_lixo");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.SituacaoPraia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_praia");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CidadePraia")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("cidade_praia");

                    b.Property<int>("NivelSujeiraPraia")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("nivelsujeira_praia");

                    b.Property<string>("NomePraia")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_praia");

                    b.HasKey("Id");

                    b.ToTable("Situacao_Praia");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.TiposLixo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_lixo");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("NomeLixo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_lixo");

                    b.Property<long?>("RecebimentoLixoId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_recebimento");

                    b.Property<decimal>("ValorKgLixo")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("valor_lixo");

                    b.HasKey("Id");

                    b.HasIndex("RecebimentoLixoId");

                    b.ToTable("tipos_lixo");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.VoluntarioPerfil", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_perfil");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PessoaId")
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_pessoa");

                    b.Property<int>("QntdLixo")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("qntdlixoretirado_perfil");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("voluntario_perfil");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.VoluntarioPessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(19)")
                        .HasColumnName("id_pessoa");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BairroEndereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("bairro_end");

                    b.Property<string>("CepEndereco")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("NVARCHAR2(8)")
                        .HasColumnName("cep_end");

                    b.Property<string>("CidadeEndereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("cidade_end");

                    b.Property<string>("CpfPessoa")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("NVARCHAR2(11)")
                        .HasColumnName("cpf_pessoa");

                    b.Property<string>("DtnascPessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(10)")
                        .HasColumnName("dtnasc_pessoa");

                    b.Property<string>("EstadoEndereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("estado_end");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_pessoa");

                    b.Property<string>("NumEndereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("num_end");

                    b.Property<string>("PaisEndereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("pais_end");

                    b.Property<string>("RuaEndereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("rua_end");

                    b.Property<string>("SenhaPessoa")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("senha_pessoa");

                    b.HasKey("Id");

                    b.ToTable("voluntario_pessoa");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.RecebimentoLixo", b =>
                {
                    b.HasOne("gs_bluehorizon_dotnet.Models.VoluntarioPerfil", "VoluntarioPerfil")
                        .WithMany("RecebimentoLixos")
                        .HasForeignKey("PerfilId");

                    b.HasOne("gs_bluehorizon_dotnet.Models.VoluntarioPessoa", "VoluntarioPessoa")
                        .WithMany("RecebimentoLixos")
                        .HasForeignKey("PessoaId");

                    b.HasOne("gs_bluehorizon_dotnet.Models.PontosColeta", "PontosColeta")
                        .WithMany("RecebimentoLixos")
                        .HasForeignKey("PontosColetaId");

                    b.Navigation("PontosColeta");

                    b.Navigation("VoluntarioPerfil");

                    b.Navigation("VoluntarioPessoa");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.TiposLixo", b =>
                {
                    b.HasOne("gs_bluehorizon_dotnet.Models.RecebimentoLixo", "RecebimentoLixo")
                        .WithMany("TiposLixos")
                        .HasForeignKey("RecebimentoLixoId");

                    b.Navigation("RecebimentoLixo");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.VoluntarioPerfil", b =>
                {
                    b.HasOne("gs_bluehorizon_dotnet.Models.VoluntarioPessoa", "VoluntarioPessoa")
                        .WithOne("Perfil")
                        .HasForeignKey("gs_bluehorizon_dotnet.Models.VoluntarioPerfil", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VoluntarioPessoa");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.PontosColeta", b =>
                {
                    b.Navigation("RecebimentoLixos");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.RecebimentoLixo", b =>
                {
                    b.Navigation("TiposLixos");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.VoluntarioPerfil", b =>
                {
                    b.Navigation("RecebimentoLixos");
                });

            modelBuilder.Entity("gs_bluehorizon_dotnet.Models.VoluntarioPessoa", b =>
                {
                    b.Navigation("Perfil");

                    b.Navigation("RecebimentoLixos");
                });
#pragma warning restore 612, 618
        }
    }
}
