using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyDDD.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Version",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Major = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Minor = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Patch = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    PreRelease = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Version");
        }
    }
}
