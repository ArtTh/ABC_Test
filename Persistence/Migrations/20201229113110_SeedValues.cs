using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Berlin" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Amsterdam" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ljubljana" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Belgrade" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Zagreb" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Sarajevo" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Prishtina" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Rome" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Paris" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Madrid" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Istanbul" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Moscow" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Stockholm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
