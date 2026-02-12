using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDomains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerformedAt",
                table: "WorkoutSessions",
                newName: "StartedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "WorkoutSessions",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "StartedAt",
                table: "WorkoutSessions",
                newName: "PerformedAt");
        }
    }
}
