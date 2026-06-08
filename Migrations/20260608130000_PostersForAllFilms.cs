using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SklepPB.Migrations
{
    public partial class PostersForAllFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int id = 11; id <= 70; id++)
            {
                migrationBuilder.UpdateData(
                    table: "Films",
                    keyColumn: "Id",
                    keyValue: id,
                    column: "Poster",
                    value: $"{id}.png");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int id = 11; id <= 70; id++)
            {
                migrationBuilder.UpdateData(
                    table: "Films",
                    keyColumn: "Id",
                    keyValue: id,
                    column: "Poster",
                    value: null);
            }
        }
    }
}
