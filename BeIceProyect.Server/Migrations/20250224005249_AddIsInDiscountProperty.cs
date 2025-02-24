using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeIceProyect.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddIsInDiscountProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInDiscount",
                table: "Sneakers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInDiscount",
                table: "Sneakers");
        }
    }
}
