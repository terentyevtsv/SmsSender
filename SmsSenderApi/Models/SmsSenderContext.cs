using Microsoft.EntityFrameworkCore;

namespace SmsSenderApi.Models
{
    public class SmsSenderContext : DbContext
    {
        public SmsSenderContext(DbContextOptions<SmsSenderContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sms_sender_db");
        }

        public DbSet<SmsMessage> SmsMessages { get; set; }
    }
}
