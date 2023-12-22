using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VariacaoAtivoFixo.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paper = table.Column<string>(type: "varchar(20)", nullable: false),
                    Date = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VariationFromPreviousDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VariationOnTheFirstDate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");
        }
    }
}
