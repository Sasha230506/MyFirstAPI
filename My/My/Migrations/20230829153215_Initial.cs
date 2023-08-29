using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Table_Tennis_UK.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TableTennisClubs",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TableTennisClubs",
                columns: new[] { "Id", "CoutOfTable", "CreateDate", "Details", "HeadCoach", "JuniorCoach", "Name", "Square", "UpdatedDate", "YearOfOpening" },
                values: new object[] { 1, 6, new DateTime(2023, 8, 29, 18, 24, 53, 266, DateTimeKind.Local).AddTicks(6705), "We should visit the Kiev Villa", "ff", "ff", "Lider", 150.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "rcrcr" });
        }
    }
}
