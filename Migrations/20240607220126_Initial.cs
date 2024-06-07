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
                name: "pontos_coleta",
                columns: table => new
                {
                    id_ponto = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_ponto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estado_ponto = table.Column<string>(type: "NVARCHAR2(2)", maxLength: 2, nullable: false),
                    gerente_ponto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pontos_coleta", x => x.id_ponto);
                });

            migrationBuilder.CreateTable(
                name: "Situacao_Praia",
                columns: table => new
                {
                    id_praia = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_praia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nivelsujeira_praia = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    cidade_praia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao_Praia", x => x.id_praia);
                });

            migrationBuilder.CreateTable(
                name: "voluntario_pessoa",
                columns: table => new
                {
                    id_pessoa = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cpf_pessoa = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    nome_pessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dtnasc_pessoa = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
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
                    id_pessoa = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voluntario_perfil", x => x.id_perfil);
                    table.ForeignKey(
                        name: "FK_voluntario_perfil_voluntario_pessoa_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "voluntario_pessoa",
                        principalColumn: "id_pessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recebimento_lixo",
                columns: table => new
                {
                    id_recebimento = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_recebimento = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    id_pontosColeta = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    id_perfil = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    id_pessoa = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recebimento_lixo", x => x.id_recebimento);
                    table.ForeignKey(
                        name: "FK_recebimento_lixo_pontos_coleta_id_pontosColeta",
                        column: x => x.id_pontosColeta,
                        principalTable: "pontos_coleta",
                        principalColumn: "id_ponto");
                    table.ForeignKey(
                        name: "FK_recebimento_lixo_voluntario_perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "voluntario_perfil",
                        principalColumn: "id_perfil");
                    table.ForeignKey(
                        name: "FK_recebimento_lixo_voluntario_pessoa_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "voluntario_pessoa",
                        principalColumn: "id_pessoa");
                });

            migrationBuilder.CreateTable(
                name: "tipos_lixo",
                columns: table => new
                {
                    id_lixo = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_lixo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    valor_lixo = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    id_recebimento = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_lixo", x => x.id_lixo);
                    table.ForeignKey(
                        name: "FK_tipos_lixo_recebimento_lixo_id_recebimento",
                        column: x => x.id_recebimento,
                        principalTable: "recebimento_lixo",
                        principalColumn: "id_recebimento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_recebimento_lixo_id_perfil",
                table: "recebimento_lixo",
                column: "id_perfil");

            migrationBuilder.CreateIndex(
                name: "IX_recebimento_lixo_id_pessoa",
                table: "recebimento_lixo",
                column: "id_pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_recebimento_lixo_id_pontosColeta",
                table: "recebimento_lixo",
                column: "id_pontosColeta");

            migrationBuilder.CreateIndex(
                name: "IX_tipos_lixo_id_recebimento",
                table: "tipos_lixo",
                column: "id_recebimento");

            migrationBuilder.CreateIndex(
                name: "IX_voluntario_perfil_id_pessoa",
                table: "voluntario_perfil",
                column: "id_pessoa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Situacao_Praia");

            migrationBuilder.DropTable(
                name: "tipos_lixo");

            migrationBuilder.DropTable(
                name: "recebimento_lixo");

            migrationBuilder.DropTable(
                name: "pontos_coleta");

            migrationBuilder.DropTable(
                name: "voluntario_perfil");

            migrationBuilder.DropTable(
                name: "voluntario_pessoa");
        }
    }
}
