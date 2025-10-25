using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matei_Raul_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class DropAuthorID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
        name: "FK_Book_Authors_AuthorID", // numele poate diferi
        table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Book");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
