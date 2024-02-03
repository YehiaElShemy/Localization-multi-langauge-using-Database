using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace whatssappnotificaion.Migrations
{
    /// <inheritdoc />
    public partial class inti1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "key",
                table: "stringResources",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_stringResources_key_LangaugeId",
                table: "stringResources",
                columns: new[] { "key", "LangaugeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_stringResources_key_LangaugeId",
                table: "stringResources");

            migrationBuilder.AlterColumn<string>(
                name: "key",
                table: "stringResources",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
