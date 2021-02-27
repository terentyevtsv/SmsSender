using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSenderApi.Migrations
{
    public partial class RemoveStringSmsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sms_id",
                schema: "sms_sender_db",
                table: "sms_message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sms_id",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 1,
                column: "sms_id",
                value: "510433335");

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 2,
                column: "sms_id",
                value: "510434281");
        }
    }
}
