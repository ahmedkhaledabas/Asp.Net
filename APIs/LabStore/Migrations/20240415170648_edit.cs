using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabStore.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Labs",
                newName: "Model");

            migrationBuilder.CreateTable(
                name: "LabImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabId = table.Column<int>(type: "int", nullable: false),
                    LabtopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabImages_Labs_LabtopId",
                        column: x => x.LabtopId,
                        principalTable: "Labs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabImages_LabtopId",
                table: "LabImages",
                column: "LabtopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabImages");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Labs",
                newName: "Image");
        }
    }
}
