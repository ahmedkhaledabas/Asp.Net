using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class usercart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Movies_MovieId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_MovieId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "ApplicationUserViewModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MovieCarts",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCarts", x => new { x.CartId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieCarts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCarts_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCarts_MovieId",
                table: "MovieCarts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "MovieCarts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "ApplicationUserViewModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_MovieId",
                table: "Carts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Movies_MovieId",
                table: "Carts",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
