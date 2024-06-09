using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class homeUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MyServices",
                columns: new[] { "Id", "HomeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MyWorks",
                columns: new[] { "Id", "HomeId" },
                values: new object[] { 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MyWorks",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
