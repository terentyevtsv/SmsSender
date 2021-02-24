using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSenderApi.Migrations
{
    public partial class SeedSmsMessageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sms_id",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "sms_sender_db",
                table: "sms_message",
                columns: new[] { "id", "message_text", "phone_number", "sender_name", "sending_date", "sms_id", "status" },
                values: new object[,]
                {
                    { 1, "тестовое сообщение2", "79270095932", "VIRTA", new DateTime(1970, 1, 19, 16, 19, 31, 72, DateTimeKind.Unspecified), "510433335", 1 },
                    { 2, "тест сообщение4тест сообщение4тест сообщение4тест сообщение4тест сообщение4тест сообщение4", "79270095932", "VIRTA", new DateTime(1970, 1, 19, 16, 19, 31, 72, DateTimeKind.Unspecified), "510434281", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "sms_id",
                schema: "sms_sender_db",
                table: "sms_message");
        }
    }
}
