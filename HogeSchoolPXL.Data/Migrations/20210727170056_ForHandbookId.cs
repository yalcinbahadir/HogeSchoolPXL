using Microsoft.EntityFrameworkCore.Migrations;

namespace HogeSchoolPXL.Data.Migrations
{
    public partial class ForHandbookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Handbooks_HandbookId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_HandbookId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "HandbookId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_HandbookId",
                table: "Courses",
                column: "HandbookId",
                unique: true,
                filter: "[HandbookId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Handbooks_HandbookId",
                table: "Courses",
                column: "HandbookId",
                principalTable: "Handbooks",
                principalColumn: "HandbookId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Handbooks_HandbookId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_HandbookId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "HandbookId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_HandbookId",
                table: "Courses",
                column: "HandbookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Handbooks_HandbookId",
                table: "Courses",
                column: "HandbookId",
                principalTable: "Handbooks",
                principalColumn: "HandbookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
