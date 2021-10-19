using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalCare.Data.Migrations
{
    public partial class addSpecialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbSpetialities",
                columns: table => new
                {
                    IdSpeciality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUser_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSpetialities", x => x.IdSpeciality);
                    table.ForeignKey(
                        name: "FK_TbSpetialities_TbUsers_IdUser_FK",
                        column: x => x.IdUser_FK,
                        principalTable: "TbUsers",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbSpetialities_IdUser_FK",
                table: "TbSpetialities",
                column: "IdUser_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbSpetialities");
        }
    }
}
