using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ytsoob.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class YtsoobIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "id",
                schema: "ytsoob",
                table: "ytsoobers",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "id",
                schema: "ytsoob",
                table: "ytsoobers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
