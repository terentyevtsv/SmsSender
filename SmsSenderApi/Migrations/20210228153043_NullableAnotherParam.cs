using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSenderApi.Migrations
{
    public partial class NullableAnotherParam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "sending_date",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "sending_date_1",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sending_date_1",
                schema: "sms_sender_db",
                table: "sms_message");

            migrationBuilder.AlterColumn<DateTime>(
                name: "sending_date",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
