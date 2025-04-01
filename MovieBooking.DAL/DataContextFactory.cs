using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MovieBooking.DAL
{
    internal class DataContextFactory: IDesignTimeDbContextFactory<MovieBookingContext>
    {
        public MovieBookingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieBookingContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database= DATABASE;Trusted_Connection = True; MultipleActiveResultSets = true");
        return new MovieBookingContext(optionsBuilder.Options);
        }
    }
}
