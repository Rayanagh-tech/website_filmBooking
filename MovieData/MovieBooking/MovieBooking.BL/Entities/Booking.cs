using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooking.BL.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int MovieId { get; set; }
        public string? SeatIds { get; set; }

        public required string ApplicationUserId { get; set; }
        public int ShowtimeId { get; set; }
        public DateTime BookingDate { get; set; }
        [Required]
        public int NumberOfSeats { get; set; } // Number of seats booked

        public string PaymentStatus { get; set; } = "Pending";

        // Navigation Properties
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual Showtime? Showtime { get; set; }

    }
}
