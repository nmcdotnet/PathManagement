using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PathManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePathModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Paths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Groups",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            //migrationBuilder.CreateTable(
            //    name: "tbSYS_Users",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Department = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Skin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        Status = table.Column<bool>(type: "bit", nullable: false),
            //        Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tbSYS_Users", x => x.id);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Paths_UserId",
                table: "Paths",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbSYS_Users_Username",
                table: "tbSYS_Users",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_tbSYS_Users_UserId",
                table: "Paths",
                column: "UserId",
                principalTable: "tbSYS_Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_tbSYS_Users_UserId",
                table: "Paths");

            migrationBuilder.DropTable(
                name: "tbSYS_Users");

            migrationBuilder.DropIndex(
                name: "IX_Paths_UserId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Paths");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Groups",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);
        }
    }
}
