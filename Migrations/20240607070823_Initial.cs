using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gs_bluehorizon_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "voluntario_pessoa",
                columns: table => new
                {
                    id_pessoa = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cpf_pessoa = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    nome_pessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dtnasc_pessoa = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    senha_pessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cep_end = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false),
                    rua_end = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    num_end = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    bairro_end = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cidade_end = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estado_end = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    pais_end = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voluntario_pessoa", x => x.id_pessoa);
                });

            migrationBuilder.CreateTable(
                name: "voluntario_perfil",
                columns: table => new
                {
                    id_perfil = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    qntdlixoretirado_perfil = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PessoaId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voluntario_perfil", x => x.id_perfil);
                    table.ForeignKey(
                        name: "FK_voluntario_perfil_voluntario_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "voluntario_pessoa",
                        principalColumn: "id_pessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_voluntario_perfil_PessoaId",
                table: "voluntario_perfil",
                column: "PessoaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "voluntario_perfil");

            migrationBuilder.DropTable(
                name: "voluntario_pessoa");
        }
    }
}
