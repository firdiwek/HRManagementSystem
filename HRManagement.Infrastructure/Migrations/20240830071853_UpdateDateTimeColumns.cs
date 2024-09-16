using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateTimeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                // Change the type of existing DateTime columns to 'timestamp with time zone'
        migrationBuilder.AlterColumn<DateTime>(
            name: "Date", // Column name in your table
            table: "AttendanceRecords", // Your table name
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp without time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "CreatedDate", // Column name in your table
            table: "AttendanceRecords", // Your table name
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp without time zone");

                // Change the type of existing DateTime columns to 'timestamp with time zone'
        migrationBuilder.AlterColumn<DateTime>(
            name: "CheckInTime", // Column name in your table
            table: "AttendanceRecords", // Your table name
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp without time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "CheckOutTime", // Column name in your table
            table: "AttendanceRecords", // Your table name
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp without time zone");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
            name: "Date",
            table: "AttendanceRecords",
            type: "timestamp without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "CreatedDate",
            table: "AttendanceRecords",
            type: "timestamp without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
            name: "CheckInTime",
            table: "AttendanceRecords",
            type: "timestamp without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");

        migrationBuilder.AlterColumn<DateTime>(
            name: "CheckOutTime",
            table: "AttendanceRecords",
            type: "timestamp without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp with time zone");


        }
    }
}
