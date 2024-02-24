using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class BookingPageMerge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DLNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DLImageFront = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DLImageBack = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BookingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
