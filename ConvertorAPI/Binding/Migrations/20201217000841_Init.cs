using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Binding.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CurrencyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "histories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FromAmount = table.Column<decimal>(nullable: false),
                    FromCurrencyId = table.Column<int>(nullable: false),
                    ToAmount = table.Column<decimal>(nullable: false),
                    ToCurrencyId = table.Column<int>(nullable: false),
                    DateConvert = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_histories_currencies_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalTable: "currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_histories_currencies_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalTable: "currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "Id", "CurrencyName" },
                values: new object[,]
                {
                    { 1, "USD" },
                    { 2, "EUR" },
                    { 3, "GBP" },
                    { 4, "CHF" }
                });

            migrationBuilder.InsertData(
                table: "histories",
                columns: new[] { "Id", "DateConvert", "FromAmount", "FromCurrencyId", "ToAmount", "ToCurrencyId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m, 1, 700m, 2 });

            migrationBuilder.InsertData(
                table: "histories",
                columns: new[] { "Id", "DateConvert", "FromAmount", "FromCurrencyId", "ToAmount", "ToCurrencyId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 2, 800m, 3 });

            migrationBuilder.InsertData(
                table: "histories",
                columns: new[] { "Id", "DateConvert", "FromAmount", "FromCurrencyId", "ToAmount", "ToCurrencyId" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, 1, 800m, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_histories_FromCurrencyId",
                table: "histories",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_histories_ToCurrencyId",
                table: "histories",
                column: "ToCurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "histories");

            migrationBuilder.DropTable(
                name: "currencies");
        }
    }
}
