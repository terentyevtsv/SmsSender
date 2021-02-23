using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsSenderApi.Models
{
    [Table("sms_message")]
    public class SmsMessage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("sender_name")]
        public string SenderName { get; set; }

        [Required]
        [Column("message_text")]
        public string MessageText { get; set; }

        [Column("sending_date")]
        public DateTime SendingDate { get; set; }

        [Column("status")]
        public SmsMessageStatus Status { get; set; }
    }

    public enum SmsMessageStatus
    {
        Sent,
        Delivered,
        SendingError
    }
}
