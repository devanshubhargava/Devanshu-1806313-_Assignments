using System.Data.Entity;

namespace MoviesDBMVC.Models
{
    public class MoviesDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        
        public MoviesDBContext() : base("name=MoviesDB_connection")
        {
        }
    }
}
