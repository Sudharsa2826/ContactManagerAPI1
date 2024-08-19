using Microsoft.EntityFrameworkCore;
using ContactManagerAPI.Models;

namespace ContactManagerAPI.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
