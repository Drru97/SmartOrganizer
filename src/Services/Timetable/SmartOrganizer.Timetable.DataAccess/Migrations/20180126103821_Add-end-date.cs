using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartOrganizer.Timetable.API.Migrations
{
	public partial class Addenddate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Duration",
				table: "Appointment");

			migrationBuilder.AddColumn<DateTime>(
				name: "EndDate",
				table: "Appointment",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "EndDate",
				table: "Appointment");

			migrationBuilder.AddColumn<TimeSpan>(
				name: "Duration",
				table: "Appointment",
				nullable: false,
				defaultValue: new TimeSpan(0, 0, 0, 0, 0));
		}
	}
}
