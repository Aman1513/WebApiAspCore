using Microsoft.EntityFrameworkCore;

namespace WebApiAspNetCore.Models
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
