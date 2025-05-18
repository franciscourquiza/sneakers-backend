using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BeIceProyect.Server.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    IsInDiscount = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Sizes = table.Column<string>(type: "text", nullable: false),
                    IsInDiscount = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Sneakers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Name = table.Column<string>(type: "text", nullable: false),
            //        Price = table.Column<float>(type: "real", nullable: false),
            //        ImageUrl = table.Column<string>(type: "text", nullable: false),
            //        IsInDiscount = table.Column<bool>(type: "boolean", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Sneakers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Email = table.Column<string>(type: "text", nullable: false),
            //        Password = table.Column<string>(type: "text", nullable: false),
            //        UserRole = table.Column<string>(type: "text", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SneakersSizes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "integer", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Size = table.Column<int>(type: "integer", nullable: false),
            //        SneakerId = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SneakersSizes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_SneakersSizes_Sneakers_SneakerId",
            //            column: x => x.SneakerId,
            //            principalTable: "Sneakers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_SneakersSizes_SneakerId",
            //    table: "SneakersSizes",
            //    column: "SneakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caps");

            migrationBuilder.DropTable(
                name: "Clothes");

            //migrationBuilder.DropTable(
            //    name: "SneakersSizes");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Sneakers");
        }
    }
}
