using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMelix.Migrations
{
    public partial class react : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "7c1a428d-c9b5-4769-8711-2d4b2968bef3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "7edbf8a2-b40f-448e-9fcf-2fe1868f2be3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "s",
                column: "ConcurrencyStamp",
                value: "91c1570f-f3ac-4b47-82b4-42857661ad59");
        }
    }
}
