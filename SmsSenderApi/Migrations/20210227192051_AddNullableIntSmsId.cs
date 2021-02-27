using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsSenderApi.Migrations
{
    public partial class AddNullableIntSmsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sms_int_id",
                schema: "sms_sender_db",
                table: "sms_message",
                newName: "sms_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sms_id",
                schema: "sms_sender_db",
                table: "sms_message",
                newName: "sms_int_id");
        }
    }
}
