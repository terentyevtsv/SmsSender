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
        public int? SmsId { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Максимальная длина номера 11 символов")]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("sender_name")]
        public string SenderName { get; set; }

        [Required]
        [MaxLength(350, ErrorMessage = "Максимальная длина 5 sms * 70 симв/sms = 350 символов")]
        [Column("message_text")]
        public string MessageText { get; set; }

        [Column("sending_date")]        
        public DateTime? SendingDate { get; set; }        

        [Column("status")]
        public SmsMessageStatus Status { get; set; }

        /// <summary>
        /// Текст статуса (В случае необходимости появляется сообщение об ошибке)
        /// </summary>
        [Column("status_text")]
        public string StatusText { get; set; }
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
