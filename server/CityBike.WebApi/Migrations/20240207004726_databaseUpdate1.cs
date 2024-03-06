using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CityBike.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class databaseUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "stations",
                type: "serial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "return_station_id",
                table: "journeys",
                type: "serial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "departure_station_id",
                table: "journeys",
                type: "serial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "stations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "serial")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "return_station_id",
                table: "journeys",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "serial");

            migrationBuilder.AlterColumn<int>(
                name: "departure_station_id",
                table: "journeys",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "serial");
        }
    }
}
