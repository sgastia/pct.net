using Microsoft.EntityFrameworkCore.Migrations;

namespace PCT.BD.Migrations
{
    public partial class AddManyToMany_ConciertosMusicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musicos_Conciertos_ConciertoIdConcierto",
                table: "Musicos");

            migrationBuilder.DropIndex(
                name: "IX_Musicos_ConciertoIdConcierto",
                table: "Musicos");

            migrationBuilder.DropColumn(
                name: "ConciertoIdConcierto",
                table: "Musicos");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Galerias",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Galerias",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConciertoMusico",
                columns: table => new
                {
                    MusicoId = table.Column<int>(nullable: false),
                    ConciertoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConciertoMusico", x => new { x.ConciertoId, x.MusicoId });
                    table.ForeignKey(
                        name: "FK_ConciertoMusico_Conciertos_ConciertoId",
                        column: x => x.ConciertoId,
                        principalTable: "Conciertos",
                        principalColumn: "IdConcierto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConciertoMusico_Musicos_MusicoId",
                        column: x => x.MusicoId,
                        principalTable: "Musicos",
                        principalColumn: "IdMusico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConciertoMusico_MusicoId",
                table: "ConciertoMusico",
                column: "MusicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConciertoMusico");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Galerias");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Galerias");

            migrationBuilder.AddColumn<int>(
                name: "ConciertoIdConcierto",
                table: "Musicos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musicos_ConciertoIdConcierto",
                table: "Musicos",
                column: "ConciertoIdConcierto");

            migrationBuilder.AddForeignKey(
                name: "FK_Musicos_Conciertos_ConciertoIdConcierto",
                table: "Musicos",
                column: "ConciertoIdConcierto",
                principalTable: "Conciertos",
                principalColumn: "IdConcierto",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
