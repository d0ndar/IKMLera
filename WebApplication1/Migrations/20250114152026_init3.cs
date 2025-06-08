using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id_event = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "varchar(100)", nullable: false),
                    description = table.Column<string>(type: "varchar(250)", nullable: false),
                    date_event = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    time_event = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    location = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    ticket_price = table.Column<int>(type: "integer", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    sponsor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id_event);
                    table.UniqueConstraint("AK_events_title", x => x.title);
                    table.UniqueConstraint("AK_events_description", x => x.description);
                    table.ForeignKey("FK_events_location", x => x.location, "location_events", "id_location_events");
                    table.ForeignKey("FK_events_category", x => x.category, "category", "id_category");
                    table.ForeignKey("FK_events_sponsor", x => x.sponsor, "organizers", "id_organizers");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
