using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.BL.Entities
{
    public class Showtime
    {
        public int ShowtimeId { get; set; }
        public DateTime StartTime { get; set; }
        public int AvailableSeats { get; set; }
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
       

        // Navigation Properties
        public virtual Movie? Movie { get; set; }
        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
