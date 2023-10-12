using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Butter.DataAccess.Migrations
{
    public partial class Cycle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.UserId)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "FriendEntity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendEntity", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_FriendEntity_UserEntity_FriendId",
                        column: x => x.FriendId,
                        principalTable: "UserEntity",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_FriendEntity_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendEntity_FriendId",
                table: "FriendEntity",
                column: "FriendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");
        }
    }
}
