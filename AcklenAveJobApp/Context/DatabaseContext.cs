using System.Data.Entity;
using AcklenAveJobApp.Entities;

namespace AcklenAveJobApp.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("AcklenJobApp") { }
        public DbSet<SecretPayload> Secrets { get; set; }
    }
}