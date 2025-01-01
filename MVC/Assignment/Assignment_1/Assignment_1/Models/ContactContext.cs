
using System.Data.Entity;

namespace Assignment_1.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext() : base("name=Database_connection")
        {
        }
    }
}