using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.BL.Entities
{
    public class BookingConfirmationViewModel
    {
        public string? Showtime { get; set; }
        public string? SeatDetails { get; set; }
        // Add other properties as needed
        public List<int>? Seats { get; set; } // Assuming you're passing seat numbers as integers
        public string? MovieTitle { get; set; }
    }

}
