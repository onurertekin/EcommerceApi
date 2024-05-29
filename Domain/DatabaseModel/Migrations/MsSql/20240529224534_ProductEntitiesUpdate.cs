using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class ProductEntitiesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductComments_ProductCommentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCommentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCommentId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCommentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCommentId",
                table: "Products",
                column: "ProductCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductComments_ProductCommentId",
                table: "Products",
                column: "ProductCommentId",
                principalTable: "ProductComments",
                principalColumn: "Id");
        }
    }
}
