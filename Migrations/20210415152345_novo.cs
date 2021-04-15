using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParcialAncelmo.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 255, nullable: true),
                    linkedin = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 255, nullable: true),
                    dataDeNascimento = table.Column<DateTime>(nullable: false),
                    sexo = table.Column<string>(maxLength: 255, nullable: true),
                    email = table.Column<string>(maxLength: 255, nullable: true),
                    telefone = table.Column<string>(maxLength: 255, nullable: true),
                    endereco = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoConteudos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConteudos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false),
                    tipo = table.Column<string>(maxLength: 500, nullable: true),
                    idCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conteudos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataDeCadastro = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    texto = table.Column<string>(maxLength: 10000, nullable: true),
                    link = table.Column<string>(maxLength: 500, nullable: true),
                    idTipoConteudo = table.Column<int>(nullable: false),
                    idAutor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteudos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conteudos_Autores_idAutor",
                        column: x => x.idAutor,
                        principalTable: "Autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conteudos_TipoConteudos_idTipoConteudo",
                        column: x => x.idTipoConteudo,
                        principalTable: "TipoConteudos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "id", "linkedin", "nome" },
                values: new object[] { 1, "www.linkedin.com/in/josefina-silva/", "Josefina da Silva" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "id", "dataDeNascimento", "email", "endereco", "nome", "sexo", "telefone" },
                values: new object[] { 1, new DateTime(2021, 4, 15, 11, 23, 45, 203, DateTimeKind.Local).AddTicks(4442), "teste123@gmail.com", "Avenida Rafael Vaz e Silva, 1111, Liberdade, Porto Velho, Rondônia", "Juscelino Peres", "Masculino", "69 9999999999" });

            migrationBuilder.InsertData(
                table: "Conteudos",
                columns: new[] { "id", "dataDeCadastro", "idAutor", "idTipoConteudo", "link", "texto" },
                values: new object[] { 1, new DateTime(2021, 4, 15, 11, 23, 45, 205, DateTimeKind.Local).AddTicks(5568), 0, 0, "siojaoisjaoijsiojoia", "sokaoskoaksok" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "id", "descricao", "idCliente", "tipo", "valor" },
                values: new object[] { 1, "nsiasiuhauhs", 0, null, 100.0 });

            migrationBuilder.InsertData(
                table: "TipoConteudos",
                columns: new[] { "id", "descricao" },
                values: new object[] { 1, "isjaoijsoiaj" });

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_idAutor",
                table: "Conteudos",
                column: "idAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Conteudos_idTipoConteudo",
                table: "Conteudos",
                column: "idTipoConteudo");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_idCliente",
                table: "Produtos",
                column: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conteudos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "TipoConteudos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
