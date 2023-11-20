using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsVanguards.API.Migrations
{
    /// <inheritdoc />
    public partial class Entrega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMeeting",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdParticipant",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeetingId",
                table: "Registers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Registers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contact_Info = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Type_Sponsorship = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Contact_inf = table.Column<string>(type: "nvarchar(950)", maxLength: 950, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EventType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingSponsors",
                columns: table => new
                {
                    IdMeeting = table.Column<int>(type: "int", nullable: false),
                    IdSponsor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: true),
                    SponsorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingSponsors", x => new { x.IdMeeting, x.IdSponsor });
                    table.ForeignKey(
                        name: "FK_MeetingSponsors_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeetingSponsors_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeetingStaffs",
                columns: table => new
                {
                    IdMeeting = table.Column<int>(type: "int", nullable: false),
                    IdEventStaff = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: true),
                    EventStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingStaffs", x => new { x.IdMeeting, x.IdEventStaff });
                    table.ForeignKey(
                        name: "FK_MeetingStaffs_EventStaffs_EventStaffId",
                        column: x => x.EventStaffId,
                        principalTable: "EventStaffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeetingStaffs_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_MeetingId",
                table: "Registers",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Registers_ParticipantId",
                table: "Registers",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OrganizerId",
                table: "Meetings",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingSponsors_MeetingId",
                table: "MeetingSponsors",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingSponsors_SponsorId",
                table: "MeetingSponsors",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingStaffs_EventStaffId",
                table: "MeetingStaffs",
                column: "EventStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingStaffs_MeetingId",
                table: "MeetingStaffs",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Meetings_MeetingId",
                table: "Registers",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Participants_ParticipantId",
                table: "Registers",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Meetings_MeetingId",
                table: "Registers");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Participants_ParticipantId",
                table: "Registers");

            migrationBuilder.DropTable(
                name: "MeetingSponsors");

            migrationBuilder.DropTable(
                name: "MeetingStaffs");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_MeetingId",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Registers_ParticipantId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "IdMeeting",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "IdParticipant",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Registers");
        }
    }
}
