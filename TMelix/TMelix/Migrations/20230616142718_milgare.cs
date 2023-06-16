using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMelix.Migrations
{
    public partial class milgare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "4013e411-520b-4ea3-a9fd-e9e08b009051");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "29fb13ba-067c-416d-8a86-01d02bbd458c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "s",
                column: "ConcurrencyStamp",
                value: "45a825b3-f4a0-43e4-86ba-076a7c5622ba");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "dc327f71-b35c-4d1d-a527-6657da0f55a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "2d02fcc9-8276-4e76-9247-58f640d12815");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "s",
                column: "ConcurrencyStamp",
                value: "b0e5d415-bc83-4760-b4f2-c762aebf3c8b");
        }
    }
}
