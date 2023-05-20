using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMelix.Migrations
{
    public partial class tentativa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "d4fabc48-3307-4998-9c04-b94470003b53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "0c90cb05-b97f-4967-bbc9-f33f4bf6f9ea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "8f0b6dc3-062b-4d05-96bc-fbf6dd1365ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "40f90d83-35c9-45b7-9bc7-a986e8de6d23");
        }
    }
}
