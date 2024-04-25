using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bus_Shuttle.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusNumber",
                table: "Buses");

            migrationBuilder.AddColumn<string>(
                name: "BusName",
                table: "Buses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusName",
                table: "Buses");

            migrationBuilder.AddColumn<int>(
                name: "BusNumber",
                table: "Buses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
