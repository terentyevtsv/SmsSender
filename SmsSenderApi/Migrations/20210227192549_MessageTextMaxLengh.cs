using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSenderApi.Migrations
{
    public partial class MessageTextMaxLengh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "message_text",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "character varying(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "message_text",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(350)",
                oldMaxLength: 350);
        }
    }
}
