using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddAvvikTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Avvik",
                table: "Avvik");

            migrationBuilder.RenameTable(
                name: "Avvik",
                newName: "Avviker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avviker",
                table: "Avviker",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Avviker",
                table: "Avviker");

            migrationBuilder.RenameTable(
                name: "Avviker",
                newName: "Avvik");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avvik",
                table: "Avvik",
                column: "Id");
        }
    }
}
