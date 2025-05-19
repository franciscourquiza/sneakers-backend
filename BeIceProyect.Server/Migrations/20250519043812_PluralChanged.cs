using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeIceProyect.Server.Migrations
{
    /// <inheritdoc />
    public partial class PluralChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sizes",
                table: "Clothes",
                newName: "Size");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Clothes",
                newName: "Sizes");
        }
    }
}
