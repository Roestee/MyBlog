using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBlog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbpdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "IsActive", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 26, 15, 48, 50, 676, DateTimeKind.Local).AddTicks(2632), "admin@ibrahimcingi.com", true, new byte[] { 72, 250, 197, 191, 108, 92, 85, 121, 141, 83, 21, 219, 46, 136, 58, 16, 170, 84, 137, 71, 0, 215, 220, 83, 80, 178, 224, 45, 218, 33, 99, 231, 255, 70, 113, 246, 2, 118, 197, 80, 44, 29, 16, 107, 179, 161, 118, 155, 32, 193, 165, 48, 192, 57, 164, 11, 161, 28, 222, 241, 71, 189, 63, 232 }, new byte[] { 247, 111, 204, 171, 151, 175, 147, 147, 1, 18, 123, 244, 119, 106, 9, 41, 133, 85, 16, 165, 233, 152, 247, 99, 151, 45, 11, 243, 104, 72, 212, 106, 139, 206, 20, 251, 188, 179, 217, 16, 88, 141, 210, 142, 70, 122, 133, 37, 74, 196, 66, 192, 62, 98, 9, 235, 225, 100, 254, 44, 221, 255, 164, 98, 174, 229, 237, 36, 12, 81, 98, 126, 242, 95, 90, 144, 189, 82, 171, 215, 101, 42, 159, 180, 111, 233, 21, 11, 237, 128, 133, 139, 66, 157, 136, 86, 179, 199, 96, 147, 249, 151, 12, 86, 160, 102, 106, 63, 28, 213, 222, 31, 55, 177, 244, 180, 234, 130, 242, 22, 15, 4, 234, 45, 122, 226, 75, 59 }, 1 },
                    { 2, new DateTime(2024, 6, 26, 15, 48, 50, 676, DateTimeKind.Local).AddTicks(2636), "test@ibrahimcingi.com", true, new byte[] { 132, 22, 240, 90, 129, 10, 86, 22, 208, 225, 83, 252, 220, 81, 28, 250, 59, 184, 21, 13, 107, 135, 137, 43, 50, 160, 48, 192, 24, 221, 95, 53, 170, 152, 34, 233, 179, 135, 232, 66, 239, 199, 148, 130, 65, 20, 80, 246, 198, 119, 97, 138, 9, 161, 12, 224, 119, 67, 201, 220, 234, 111, 212, 248 }, new byte[] { 240, 248, 28, 4, 33, 135, 108, 42, 188, 226, 143, 30, 232, 203, 233, 106, 163, 39, 20, 88, 172, 109, 77, 155, 23, 178, 15, 184, 62, 53, 156, 167, 179, 239, 49, 18, 94, 133, 199, 204, 50, 22, 187, 110, 120, 176, 27, 236, 138, 41, 172, 196, 249, 123, 225, 161, 182, 79, 78, 17, 193, 12, 146, 129, 48, 235, 70, 5, 9, 115, 108, 119, 189, 50, 43, 219, 165, 128, 38, 250, 30, 205, 221, 145, 105, 153, 35, 112, 162, 219, 242, 1, 9, 74, 111, 203, 83, 221, 159, 155, 68, 238, 6, 151, 88, 225, 17, 233, 248, 168, 24, 136, 105, 105, 242, 248, 203, 202, 237, 87, 119, 233, 147, 112, 41, 181, 193, 242 }, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
