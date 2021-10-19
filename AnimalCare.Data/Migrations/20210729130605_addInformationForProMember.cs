using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalCare.Data.Migrations
{
    public partial class addInformationForProMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbInofrmationForProMember");

            migrationBuilder.CreateTable(
                name: "TbInformationForProMember",
                columns: table => new
                {
                    IdInfoProMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isValidSubscribe = table.Column<bool>(type: "bit", nullable: false),
                    ActiveSubscribe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbInformationForProMember", x => x.IdInfoProMember);
                    table.ForeignKey(
                        name: "FK_TbInformationForProMember_TbUsers_UserId_Fk",
                        column: x => x.UserId_Fk,
                        principalTable: "TbUsers",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbInformationForProMember_UserId_Fk",
                table: "TbInformationForProMember",
                column: "UserId_Fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbInformationForProMember");

            migrationBuilder.CreateTable(
                name: "TbInofrmationForProMember",
                columns: table => new
                {
                    IdInfoProMember = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveSubscribe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId_Fk = table.Column<int>(type: "int", nullable: false),
                    isValidSubscribe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbInofrmationForProMember", x => x.IdInfoProMember);
                    table.ForeignKey(
                        name: "FK_TbInofrmationForProMember_TbUsers_UserId_Fk",
                        column: x => x.UserId_Fk,
                        principalTable: "TbUsers",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbInofrmationForProMember_UserId_Fk",
                table: "TbInofrmationForProMember",
                column: "UserId_Fk");
        }
    }
}
