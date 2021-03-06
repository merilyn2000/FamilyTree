using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTree.Data.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    FriendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.FriendId);
                });

            migrationBuilder.CreateTable(
                name: "FriendPerson",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendPerson", x => new { x.FriendId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_FriendPerson_Friends_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friends",
                        principalColumn: "FriendId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendPerson_PersonId",
                table: "FriendPerson",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendPerson");

            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
