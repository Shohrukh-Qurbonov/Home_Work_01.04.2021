using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[,]
                {
                    { 1, "Альберт Эйнштейн", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "Стремитесь не к успеху, а к ценностям, которые он дает." },
                    { 2, "Флоренс Найтингейл", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "Своим успехом я обязана тому, что никогда не оправдывалась и не принимала оправданий от других." },
                    { 3, "Амелия Эрхарт", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "Сложнее всего начать действовать, все остальное зависит только от упорства." },
                    { 4, "Федор Достоевский", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "Надо любить жизнь больше, чем смысл жизни." },
                    { 5, "Альберт Эйнштейн", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "Логика может привести Вас от пункта А к пункту Б, а воображение — куда угодно." },
                    { 6, "Борис Стругацкий", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "Начинать всегда стоит с того, что сеет сомнения." },
                    { 7, "Вуди Аллен", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "80% успеха - это появиться в нужном месте в нужное время." },
                    { 8, "Стив Джобс", new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Local), "Ваше время ограничено, не тратьте его, живя чужой жизнью." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
