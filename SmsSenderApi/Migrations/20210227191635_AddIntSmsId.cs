using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSenderApi.Migrations
{
    public partial class AddIntSmsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sms_int_id",
                schema: "sms_sender_db",
                table: "sms_message",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 1,
                column: "sms_int_id",
                value: 510433335);

            migrationBuilder.UpdateData(
                schema: "sms_sender_db",
                table: "sms_message",
                keyColumn: "id",
                keyValue: 2,
                column: "sms_int_id",
                value: 510434281);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sms_int_id",
                schema: "sms_sender_db",
                table: "sms_message");
        }
    }
}
