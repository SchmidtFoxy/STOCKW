using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STOCKW.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    ID_Cidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.ID_Cidade);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    ID_Item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dimensao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Caracteristica = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.ID_Item);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    ID_Permissao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoPermissao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.ID_Permissao);
                });

            migrationBuilder.CreateTable(
                name: "TiposMovimentacao",
                columns: table => new
                {
                    ID_TipoMovimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMovimentacao", x => x.ID_TipoMovimentacao);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    ID_Pessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Cidade = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.ID_Pessoa);
                    table.ForeignKey(
                        name: "FK_Pessoas_Cidades_ID_Cidade",
                        column: x => x.ID_Cidade,
                        principalTable: "Cidades",
                        principalColumn: "ID_Cidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Permissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Permissoes_ID_Permissao",
                        column: x => x.ID_Permissao,
                        principalTable: "Permissoes",
                        principalColumn: "ID_Permissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    ID_Movimentacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Item = table.Column<int>(type: "int", nullable: false),
                    ID_Entidade = table.Column<int>(type: "int", nullable: false),
                    ID_TipoMovimentacao = table.Column<int>(type: "int", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeMovimentada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.ID_Movimentacao);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Itens_ID_Item",
                        column: x => x.ID_Item,
                        principalTable: "Itens",
                        principalColumn: "ID_Item",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Pessoas_ID_Entidade",
                        column: x => x.ID_Entidade,
                        principalTable: "Pessoas",
                        principalColumn: "ID_Pessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_TiposMovimentacao_ID_TipoMovimentacao",
                        column: x => x.ID_TipoMovimentacao,
                        principalTable: "TiposMovimentacao",
                        principalColumn: "ID_TipoMovimentacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Usuarios_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ID_Entidade",
                table: "Movimentacoes",
                column: "ID_Entidade");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ID_Item",
                table: "Movimentacoes",
                column: "ID_Item");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ID_TipoMovimentacao",
                table: "Movimentacoes",
                column: "ID_TipoMovimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ID_Usuario",
                table: "Movimentacoes",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ID_Cidade",
                table: "Pessoas",
                column: "ID_Cidade");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_Permissao",
                table: "Usuarios",
                column: "ID_Permissao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "TiposMovimentacao");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Permissoes");
        }
    }
}
