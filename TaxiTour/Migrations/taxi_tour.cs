using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiTour.Migrations
{
    public partial class taxi_tour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookedTaxis",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    TaxiId = table.Column<int>(nullable: true),
                    BookingDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedTaxis", x => x.id);
                    table.ForeignKey(
                         name: "FK_PK_BookedTaxis_Taxi_taxiId",
                         column: x => x.TaxiId,
                         principalTable: "Taxi",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedTaxis");

            migrationBuilder.DropTable(
                name: "Taxi");

            migrationBuilder.DropTable(
                name: "ContactUs");
        }
    }
}
