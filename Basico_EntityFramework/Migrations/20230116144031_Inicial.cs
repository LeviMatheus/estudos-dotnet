using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsandoEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Codigodoproduto = table.Column<int>(name: "Codigo_do_produto", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomedoproduto = table.Column<string>(name: "Nome_do_produto", type: "varchar(200)", nullable: true),
                    Embalagemdoproduto = table.Column<string>(name: "Embalagem_do_produto", type: "nvarchar(max)", nullable: true),
                    Tamanhodoproduto = table.Column<string>(name: "Tamanho_do_produto", type: "nvarchar(max)", nullable: true),
                    Sabordoproduto = table.Column<string>(name: "Sabor_do_produto", type: "nvarchar(max)", nullable: true),
                    Precodoproduto = table.Column<decimal>(name: "Preco_do_produto", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Codigodoproduto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
