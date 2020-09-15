using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("1548d4d6-f6af-11ea-adc1-0242ac120002"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metallica" },
                    { new Guid("1548d71a-f6af-11ea-adc1-0242ac120002"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns N Roses" },
                    { new Guid("1548d81e-f6af-11ea-adc1-0242ac120002"), new DateTime(1965, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desco", "ABBA" },
                    { new Guid("1548d8f0-f6af-11ea-adc1-0242ac120002"), new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Oasis" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("aa1700a6-f6af-11ea-adc1-0242ac120002"), new Guid("1548d4d6-f6af-11ea-adc1-0242ac120002"), "One of the best ever", "Master of Puppets" },
                    { new Guid("aa17043e-f6af-11ea-adc1-0242ac120002"), new Guid("1548d71a-f6af-11ea-adc1-0242ac120002"), "One of the best ever", "GunsNRoses Album" },
                    { new Guid("aa170736-f6af-11ea-adc1-0242ac120002"), new Guid("1548d81e-f6af-11ea-adc1-0242ac120002"), "One of the best ever", "Abba Album" },
                    { new Guid("aa170844-f6af-11ea-adc1-0242ac120002"), new Guid("1548d8f0-f6af-11ea-adc1-0242ac120002"), "One of the best ever", "Oasis Album" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
