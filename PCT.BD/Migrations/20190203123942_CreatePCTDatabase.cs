using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCT.BD.Migrations
{
    public partial class CreatePCTDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conciertos",
                columns: table => new
                {
                    IdConcierto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Publicar = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    UrlPoster = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conciertos", x => x.IdConcierto);
                });

            migrationBuilder.CreateTable(
                name: "Galerias",
                columns: table => new
                {
                    IdGaleria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galerias", x => x.IdGaleria);
                });

            migrationBuilder.CreateTable(
                name: "Musicos",
                columns: table => new
                {
                    IdMusico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    Instrumentos = table.Column<int>(nullable: false),
                    Publicar = table.Column<bool>(nullable: false),
                    EsIntegrantePermanente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicos", x => x.IdMusico);
                });

            migrationBuilder.CreateTable(
                name: "ItemsGaleria",
                columns: table => new
                {
                    IdItemGaleria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    GaleriaIdGaleria = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsGaleria", x => x.IdItemGaleria);
                    table.ForeignKey(
                        name: "FK_ItemsGaleria_Galerias_GaleriaIdGaleria",
                        column: x => x.GaleriaIdGaleria,
                        principalTable: "Galerias",
                        principalColumn: "IdGaleria",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ItemsGaleria_GaleriaIdGaleria",
                table: "ItemsGaleria",
                column: "GaleriaIdGaleria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConciertoMusico");

            migrationBuilder.DropTable(
                name: "ItemsGaleria");

            migrationBuilder.DropTable(
                name: "Conciertos");

            migrationBuilder.DropTable(
                name: "Musicos");

            migrationBuilder.DropTable(
                name: "Galerias");
        }
    }
}
