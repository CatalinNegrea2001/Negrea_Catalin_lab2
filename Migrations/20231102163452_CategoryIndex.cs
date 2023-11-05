using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negrea_Catalin_lab2.Migrations
{
    public partial class CategoryIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CategoryID",
                table: "Authors",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Category_CategoryID",
                table: "Authors",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Category_CategoryID",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Authors_CategoryID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Authors");
        }
    }
}
