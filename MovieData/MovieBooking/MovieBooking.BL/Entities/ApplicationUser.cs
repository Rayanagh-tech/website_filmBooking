using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieBooking.BL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }

        public byte[]? ProfilePicture { get; set; } // Make this nullable

        // Ensure the collection is initialized
        public ICollection<Booking> Bookings { get; set; }

        // Parameterless constructor (required by EF Core)
        public ApplicationUser()
        {
            Bookings = new HashSet<Booking>();
        }

        // Constructor for custom use cases
        public ApplicationUser(ICollection<Booking> bookings)
        {
            Bookings = bookings;
        }
    }
}

