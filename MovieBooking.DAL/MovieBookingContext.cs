using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieBooking.BL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;




namespace MovieBooking.DAL
{
    

    public class MovieBookingContext : IdentityDbContext<ApplicationUser>
    {
        public MovieBookingContext(DbContextOptions options) : base(options)
        {
        }

        // DbSets (Tables)
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog = DATABASE; Integrated Security = true").EnableSensitiveDataLogging(); ;
            // Ensure SQL Server is correctly set up
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // ApplicationApplicationUser and Booking (1-to-Many)
            modelBuilder.Entity<Booking>()
                        .HasOne(b => b.ApplicationUser)
                        .WithMany(u => u.Bookings)
                        .HasForeignKey(b => b.ApplicationUserId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Booking and Payment (1-to-1)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Movie and Showtime (1-to-Many)
            modelBuilder.Entity<Showtime>()
                .HasOne(s => s.Movie)
                .WithMany(m => m.Showtimes)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // Showtime and Seat (1-to-Many)
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Showtime)
                .WithMany(st => st.Seats)
                .HasForeignKey(s => s.ShowtimeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking and Showtime (Many-to-1)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Showtime)
                .WithMany(st => st.Bookings)
                .HasForeignKey(b => b.ShowtimeId)
                .OnDelete(DeleteBehavior.Restrict);


            new DbInitializer(modelBuilder).Seed();
        }
    }



    internal class DbInitializer
    {
        private byte[] GetImageAsBytes(string filePath)
        {
            return File.Exists(filePath) ? File.ReadAllBytes(filePath) : Array.Empty<byte>();
        }
        private readonly ModelBuilder modelBuilder;
        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {


            // Seed ApplicationUsers
            _ = modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser(new List<Booking>())
                {
                    Id = "1",
                    FirstName = "John",
                    LastName = "Doe",
                    ProfilePicture = GetImageAsBytes("image/image1.jpeg"),
                    Bookings = new List<Booking>()  // Ensure Bookings is initialized

                },
                new ApplicationUser(new List<Booking>())
                {
                    Id = "2",
                    FirstName = "Jane",
                    LastName = "Doe",
                    ProfilePicture = GetImageAsBytes("image/image2.jpeg"),
                    Bookings = new List<Booking>()  // Ensure Bookings is initialized

                },
                new ApplicationUser(new List<Booking>())
                {
                    Id = "3",
                    FirstName = "Alice",
                    LastName = "Smith",
                    UserName = "alicesmith",
                    Email = "alice.smith@example.com",
                    ProfilePicture = GetImageAsBytes("image/image3.jpeg"),
                    Bookings = new List<Booking>()  // Ensure Bookings is initialized

                }
            );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 10, Title = "Inception", Genre = "Sci-Fi", Duration = 148, Description = "A thief who steals corporate secrets through dream-sharing.", ReleaseDate = new DateTime(2010, 7, 16),
                    MoviePicture = GetImageAsBytes("image/inception.jpeg") // Local image path
                },
                new Movie { MovieId = 20, Title = "The Dark Knight", Genre = "Action", Duration = 152, Description = "Batman battles the Joker in Gotham City.", ReleaseDate = new DateTime(2008, 7, 18), MoviePicture = GetImageAsBytes("image/dark-knight.jpeg") },
                new Movie { MovieId = 30, Title = "Interstellar", Genre = "Sci-Fi", Duration = 169, Description = "A team of explorers travel through a wormhole in space to ensure humanity's survival.", ReleaseDate = new DateTime(2014, 11, 7), MoviePicture = GetImageAsBytes("image/interstellar.jpeg") },
                new Movie { MovieId = 40, Title = "pulp-fiction", Genre = "Action", Duration = 181, Description = "The Avengers assemble to reverse the damage caused by Thanos.", ReleaseDate = new DateTime(2019, 4, 26), MoviePicture = GetImageAsBytes("image/pulp-fiction.jpeg") }
            );

            // Seed Showtimes
            modelBuilder.Entity<Showtime>().HasData(
                new Showtime { ShowtimeId = 1, MovieId = 10, ScreenId = 1, StartTime = new DateTime(2024, 12, 10, 18, 0, 0), AvailableSeats = 10 },
                new Showtime { ShowtimeId = 2, MovieId = 20, ScreenId = 1, StartTime = new DateTime(2024, 12, 11, 20, 0, 0), AvailableSeats = 15 },
                new Showtime { ShowtimeId = 3, MovieId = 30, ScreenId = 2, StartTime = new DateTime(2024, 12, 12, 21, 30, 0), AvailableSeats = 20 },
                new Showtime { ShowtimeId = 4, MovieId = 40, ScreenId = 3, StartTime = new DateTime(2024, 12, 13, 19, 0, 0), AvailableSeats = 25 }
            );


            // Seed Seats for each Showtime (5x5 grid)
            var rows = new[] { "A", "B", "C", "D", "E" };
            var columns = new[] { "1", "2", "3", "4", "5" };

            foreach (var showtimeId in new[] { 1, 2, 3, 4 }) // Seed seats for all showtimes
            {
                foreach (var row in rows)
                {
                    foreach (var column in columns)
                    {
                        modelBuilder.Entity<Seat>().HasData(new Seat
                        {
                            SeatId = showtimeId * 100 + Array.IndexOf(rows, row) * 10 + Array.IndexOf(columns, column),
                            ShowtimeId = showtimeId,
                            Row = row,
                            Column = column,
                            IsBooked = false
                        });
                    }
                }
            }

            // Seed Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    BookingId = 10,
                    MovieId = 10,
                    ShowtimeId = 1,
                    ApplicationUserId = "1",
                    BookingDate = DateTime.Now,
                    NumberOfSeats = 2,
                    SeatIds = "1,2",
                    PaymentStatus = "Paid"
                },
                new Booking
                {
                    BookingId = 20,
                    MovieId = 20,
                    ShowtimeId = 2,
                    ApplicationUserId = "2",
                    BookingDate = DateTime.Now,
                    NumberOfSeats = 1,
                    SeatIds = "3",
                    PaymentStatus = "Pending"
                }
            );

                // Seed Payments
                modelBuilder.Entity<Payment>().HasData(
                    new Payment
                    {
                        PaymentId = 1,
                        BookingId = 10,
                        Amount = 20.00m,
                        PaymentDate = DateTime.Now,
                        PaymentMethod = "Credit Card"
                    },
                    new Payment
                    {
                        PaymentId = 2,
                        BookingId = 20,
                        Amount = 15.00m,
                        PaymentDate = DateTime.Now,
                        PaymentMethod = "PayPal"
                    }
                );

            }
        }
    }

