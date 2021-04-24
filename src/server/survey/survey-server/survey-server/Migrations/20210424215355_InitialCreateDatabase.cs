using Microsoft.EntityFrameworkCore.Migrations;

namespace survey_server.Migrations
{
    public partial class InitialCreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaAtuacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrabalhouAzure = table.Column<bool>(type: "bit", nullable: false),
                    TrabalhouAws = table.Column<bool>(type: "bit", nullable: false),
                    TrabalhouGoogleCloud = table.Column<bool>(type: "bit", nullable: false),
                    NivelInteresseGoogleCloud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyEntity");
        }
    }
}
