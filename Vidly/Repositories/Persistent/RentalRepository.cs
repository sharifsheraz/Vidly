using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Repositories.Core;

namespace Vidly.Repositories.Persistent
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(ApplicationDbContext context):base(context)
        {

        }
        public int CreateNewRentals(NewRentalDto rentalDto)
        {
            var customer = _context.Customers.Single
                (c => c.Id == rentalDto.CustomerId);
            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return -1;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
                movie.NumberAvailable -= 1;
            }
            return 1;
        }
        private ApplicationDbContext _context
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}