using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SmsSenderApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sms_sender_db");

            migrationBuilder.CreateTable(
                name: "sms_message",
                schema: "sms_sender_db",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sms_id = table.Column<int>(type: "integer", nullable: true),
                    phone_number = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    sender_name = table.Column<string>(type: "text", nullable: true),
                    message_text = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    sending_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sms_message", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "sms_sender_db",
                table: "sms_message",
                columns: new[] { "id", "message_text", "phone_number", "sender_name", "sending_date", "sms_id", "status" },
                values: new object[,]
                {
                    { 1, "тестовое сообщение2", "79270095932", "VIRTA", new DateTime(2021, 2, 22, 5, 17, 52, 0, DateTimeKind.Unspecified), 510433335, 1 },
                    { 2, "тест сообщение4тест сообщение4тест сообщение4тест сообщение4тест сообщение4тест сообщение4", "79270095932", "VIRTA", new DateTime(2021, 2, 22, 5, 17, 52, 0, DateTimeKind.Unspecified), 510434281, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sms_message",
                schema: "sms_sender_db");
        }
    }
}
