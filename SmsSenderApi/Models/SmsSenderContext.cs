using Microsoft.EntityFrameworkCore;
using System;

namespace SmsSenderApi.Models
{
    public class SmsSenderContext : DbContext
    {
        public SmsSenderContext(DbContextOptions<SmsSenderContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sms_sender_db");

            var sentDate = new DateTime(1970, 1, 1, 0, 0, 0, 0)
                .AddSeconds(1613971072);
            modelBuilder.Entity<SmsMessage>().HasData(
                new SmsMessage
                {
                    Id = 1,
                    PhoneNumber = "79270095932",
                    MessageText = "тестовое сообщение2",
                    SenderName = "VIRTA",
                    Status = SmsMessageStatus.Delivered,
                    SendingDate = sentDate,                    
                    SmsId = 510433335
                },
                new SmsMessage
                {
                    Id = 2,
                    PhoneNumber = "79270095932",
                    MessageText = "тест сообщение4тест сообщение4тест сообщение4тест сообщение4тест сообщение4тест сообщение4",
                    SenderName = "VIRTA",
                    Status = SmsMessageStatus.Delivered,
                    SendingDate = sentDate,                    
                    SmsId = 510434281
                });
        }

        public DbSet<SmsMessage> SmsMessages { get; set; }
    }
}
