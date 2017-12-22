using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmartOrganizer.Timetable.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "appointment_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropSequence(
                name: "appointment_hilo");
        }
    }
}
