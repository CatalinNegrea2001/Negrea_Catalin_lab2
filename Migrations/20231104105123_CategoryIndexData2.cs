using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negrea_Catalin_lab2.Migrations
{
    public partial class CategoryIndexData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Category_CategoryID",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_CategoryID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Authors",
                type: "int",
                nullable: true);

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
        }
    }
}
