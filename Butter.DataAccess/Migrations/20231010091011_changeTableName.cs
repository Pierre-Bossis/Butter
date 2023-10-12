using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Butter.DataAccess.Migrations
{
    public partial class changeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendEntity_UserEntity_FriendId",
                table: "FriendEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendEntity_UserEntity_UserId",
                table: "FriendEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendEntity",
                table: "FriendEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "FriendEntity",
                newName: "Friends");

            migrationBuilder.RenameIndex(
                name: "IX_FriendEntity_FriendId",
                table: "Friends",
                newName: "IX_Friends_FriendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                columns: new[] { "UserId", "FriendId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_FriendId",
                table: "Friends",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Users_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_FriendId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Users_UserId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "FriendEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_FriendId",
                table: "FriendEntity",
                newName: "IX_FriendEntity_FriendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "UserId")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendEntity",
                table: "FriendEntity",
                columns: new[] { "UserId", "FriendId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendEntity_UserEntity_FriendId",
                table: "FriendEntity",
                column: "FriendId",
                principalTable: "UserEntity",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendEntity_UserEntity_UserId",
                table: "FriendEntity",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "UserId");
        }
    }
}
