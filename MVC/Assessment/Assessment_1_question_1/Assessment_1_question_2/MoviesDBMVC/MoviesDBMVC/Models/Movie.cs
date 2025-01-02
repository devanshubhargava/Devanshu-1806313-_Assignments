using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesDBMVC.Models
{
    public class Movie
    {
        
        [Key]
        public int MovieId { get; set; }

        public string MovieName { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}

