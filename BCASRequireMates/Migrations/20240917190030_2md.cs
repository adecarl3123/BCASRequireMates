using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BCASRequireMates.Migrations
{
    /// <inheritdoc />
    public partial class _2md : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmitRequest_AspNetUsers_UserId",
                table: "SubmitRequest");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SubmitRequest",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmitRequest_AspNetUsers_UserId",
                table: "SubmitRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmitRequest_AspNetUsers_UserId",
                table: "SubmitRequest");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SubmitRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmitRequest_AspNetUsers_UserId",
                table: "SubmitRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
