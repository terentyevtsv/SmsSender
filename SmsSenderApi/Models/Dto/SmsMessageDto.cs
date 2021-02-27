using System;

namespace SmsSenderApi.Models.Dto
{
    public class SmsMessageDto
    {
        public int Id { get; set; }

        public DateTime SendingDate { get; set; }

        public SmsMessageStatus Status { get; set; }
    }
}
