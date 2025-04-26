using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreFuels.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Authorizations_AuthorizationsId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AuthorizationsId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AuthorizationsId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => new { x.ProductsProductId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserProducts_Authorizations_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Authorizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProducts_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UsersId",
                table: "UserProducts",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.AddColumn<int>(
                name: "AuthorizationsId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_AuthorizationsId",
                table: "Product",
                column: "AuthorizationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Authorizations_AuthorizationsId",
                table: "Product",
                column: "AuthorizationsId",
                principalTable: "Authorizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
