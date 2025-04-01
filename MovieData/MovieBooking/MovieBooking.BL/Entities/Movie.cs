using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.BL.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required, MaxLength(150)]
        public string? Title { get; set; }
        [Required]
        public string? Genre { get; set; }
        public int Duration { get; set; }
        [Required]
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public byte[]? MoviePicture { get; set; } // Make this nullable

        // Navigation Property
        public virtual ICollection<Showtime> Showtimes { get; set; } = [];// Initialize with a default
    }
}
