using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practical3.DataAccess.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fdee873-227c-4ded-accc-5f9783a8a29f", "965fe15d-820c-4f4e-9f00-18968e33dfdd", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6868958f-52cc-40b5-885c-652d3f4969d1", "f097f9ed-ac21-4cd7-93c8-d868ca5a03e3", "HR", "HR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ecd1f89-2f6a-417e-b6d4-6132fe61ea04", "367e45f5-247a-4d45-b9af-ac91e0c68364", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fdee873-227c-4ded-accc-5f9783a8a29f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6868958f-52cc-40b5-885c-652d3f4969d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ecd1f89-2f6a-417e-b6d4-6132fe61ea04");
        }
    }
}
