using System;
using Microsoft.EntityFrameworkCore;

namespace MessageProcessApi.Models
{
    public class MessageDbContext : DbContext
    {
        public DbSet<MsgFormatA> MsgFormatA { get; set; }

        public MessageDbContext(DbContextOptions<MessageDbContext> options): base(options)
        {

        }
    }
}
