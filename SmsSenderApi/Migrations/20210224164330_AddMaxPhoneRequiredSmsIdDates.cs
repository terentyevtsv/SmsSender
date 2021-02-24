using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSenderApi.Migrations
{
    public partial class AddMaxPhoneRequiredSmsIdDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "sms_id",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 1,
                column: "sending_date",
                value: new DateTime(2021, 2, 22, 5, 17, 52, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 2,
                column: "sending_date",
                value: new DateTime(2021, 2, 22, 5, 17, 52, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "sms_id",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 1,
                column: "sending_date",
                value: new DateTime(1970, 1, 19, 16, 19, 31, 72, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 2,
                column: "sending_date",
                value: new DateTime(1970, 1, 19, 16, 19, 31, 72, DateTimeKind.Unspecified));
        }
    }
}
