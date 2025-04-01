using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.BL.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }

        [ForeignKey("Showtime")]
        public int SeatNumber { get; set; }

        public int ShowtimeId { get; set; }
        public string? Row { get; set; } // Initialize with a default value
        public string? Column { get; set; }  // Initialize with a default value
        public bool IsBooked { get; set; }

        // Navigation Property

        public virtual Showtime? Showtime { get; set; }
       

        public int MovieId { get; set; }
    }
}
