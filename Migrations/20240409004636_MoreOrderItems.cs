using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHPWServer.Migrations
{
    public partial class MoreOrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "Id", "ItemId", "OrderId" },
                values: new object[] { 3, 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
