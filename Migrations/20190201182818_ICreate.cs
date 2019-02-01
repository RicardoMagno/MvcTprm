using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcTprm.Migrations
{
    public partial class ICreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEmpresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Dividas",
                columns: table => new
                {
                    DividaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    ClienteNome = table.Column<string>(nullable: true),
                    ValorDaDivida = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividas", x => x.DividaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeServicos",
                columns: table => new
                {
                    TipoDeServicoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeServico = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeServicos", x => x.TipoDeServicoId);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    TransacaoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteContratanteId = table.Column<int>(nullable: false),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    ContratadaId = table.Column<int>(nullable: false),
                    NomeEmpresaContratada = table.Column<string>(nullable: true),
                    tipoDeServico = table.Column<string>(nullable: true),
                    valorDoServico = table.Column<decimal>(nullable: false),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.TransacaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Dividas");

            migrationBuilder.DropTable(
                name: "TipoDeServicos");

            migrationBuilder.DropTable(
                name: "Transacoes");
        }
    }
}
