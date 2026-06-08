using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SklepPB.Migrations
{
    public partial class PostersForAllFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Filmy 11-70 otrzymują plakaty rotacyjnie (1.png - 10.png)
            var posters = new[]
            {
                // Id, poster
                new { Id = 11, Poster = "1.png" },
                new { Id = 12, Poster = "2.png" },
                new { Id = 13, Poster = "3.png" },
                new { Id = 14, Poster = "4.png" },
                new { Id = 15, Poster = "5.png" },
                new { Id = 16, Poster = "6.png" },
                new { Id = 17, Poster = "7.png" },
                new { Id = 18, Poster = "8.png" },
                new { Id = 19, Poster = "9.png" },
                new { Id = 20, Poster = "10.png" },
                new { Id = 21, Poster = "1.png" },
                new { Id = 22, Poster = "2.png" },
                new { Id = 23, Poster = "3.png" },
                new { Id = 24, Poster = "4.png" },
                new { Id = 25, Poster = "5.png" },
                new { Id = 26, Poster = "6.png" },
                new { Id = 27, Poster = "7.png" },
                new { Id = 28, Poster = "8.png" },
                new { Id = 29, Poster = "9.png" },
                new { Id = 30, Poster = "10.png" },
                new { Id = 31, Poster = "1.png" },
                new { Id = 32, Poster = "2.png" },
                new { Id = 33, Poster = "3.png" },
                new { Id = 34, Poster = "4.png" },
                new { Id = 35, Poster = "5.png" },
                new { Id = 36, Poster = "6.png" },
                new { Id = 37, Poster = "7.png" },
                new { Id = 38, Poster = "8.png" },
                new { Id = 39, Poster = "9.png" },
                new { Id = 40, Poster = "10.png" },
                new { Id = 41, Poster = "1.png" },
                new { Id = 42, Poster = "2.png" },
                new { Id = 43, Poster = "3.png" },
                new { Id = 44, Poster = "4.png" },
                new { Id = 45, Poster = "5.png" },
                new { Id = 46, Poster = "6.png" },
                new { Id = 47, Poster = "7.png" },
                new { Id = 48, Poster = "8.png" },
                new { Id = 49, Poster = "9.png" },
                new { Id = 50, Poster = "10.png" },
                new { Id = 51, Poster = "1.png" },
                new { Id = 52, Poster = "2.png" },
                new { Id = 53, Poster = "3.png" },
                new { Id = 54, Poster = "4.png" },
                new { Id = 55, Poster = "5.png" },
                new { Id = 56, Poster = "6.png" },
                new { Id = 57, Poster = "7.png" },
                new { Id = 58, Poster = "8.png" },
                new { Id = 59, Poster = "9.png" },
                new { Id = 60, Poster = "10.png" },
                new { Id = 61, Poster = "1.png" },
                new { Id = 62, Poster = "2.png" },
                new { Id = 63, Poster = "3.png" },
                new { Id = 64, Poster = "4.png" },
                new { Id = 65, Poster = "5.png" },
                new { Id = 66, Poster = "6.png" },
                new { Id = 67, Poster = "7.png" },
                new { Id = 68, Poster = "8.png" },
                new { Id = 69, Poster = "9.png" },
                new { Id = 70, Poster = "10.png" },
            };

            foreach (var item in posters)
            {
                migrationBuilder.UpdateData(
                    table: "Films",
                    keyColumn: "Id",
                    keyValue: item.Id,
                    column: "Poster",
                    value: item.Poster);
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
