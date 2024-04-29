using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ytsoob.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ytsoob");

            migrationBuilder.CreateTable(
                name: "profiles",
                schema: "ytsoob",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profiles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ytsoobers",
                schema: "ytsoob",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    profile_id = table.Column<long>(type: "bigint", nullable: false),
                    creating_completed = table.Column<bool>(type: "boolean", nullable: false),
                    identity_id = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    created_by = table.Column<int>(type: "integer", nullable: true),
                    original_version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ytsoobers", x => x.id);
                    table.ForeignKey(
                        name: "fk_ytsoobers_profiles_profile_id",
                        column: x => x.profile_id,
                        principalSchema: "ytsoob",
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_profiles_id",
                schema: "ytsoob",
                table: "profiles",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ytsoobers_id",
                schema: "ytsoob",
                table: "ytsoobers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_ytsoobers_profile_id",
                schema: "ytsoob",
                table: "ytsoobers",
                column: "profile_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ytsoobers",
                schema: "ytsoob");

            migrationBuilder.DropTable(
                name: "profiles",
                schema: "ytsoob");
        }
    }
}
