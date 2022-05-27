using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoneAPI.Migrations
{
    public partial class UpdateTodoIdColumnAsUUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Todo",
                newName: "identifier");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<string>(
                name: "identifier",
                table: "Todo",
                type: "varchar(36)",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()",
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "identifier",
                table: "Todo",
                newName: "Id");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Todo",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldDefaultValueSql: "uuid_generate_v4()");
        }
    }
}
