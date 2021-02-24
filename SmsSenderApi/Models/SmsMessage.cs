using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsSenderApi.Models
{
    [Table("sms_message")]
    public class SmsMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("sms_id")]
        public string SmsId { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Максимальная длина номера 11 символов")]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("sender_name")]
        public string SenderName { get; set; }

        [Required]
        [Column("message_text")]
        public string MessageText { get; set; }

        [Required]
        [Column("sending_date")]
        public DateTime SendingDate { get; set; }

        [Column("status")]
        public SmsMessageStatus Status { get; set; }
    }

    public enum SmsMessageStatus
    {
        [Description("Отправлено")]
        Sent,

        [Description("Доставлено")]
        Delivered,

        [Description("Ошибка отправки")]
        SendingError
    }
}
