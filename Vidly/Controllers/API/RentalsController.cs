using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie not available.");

                var rental = new Rental
                {
                    Customer=customer,
                    Movie=movie,
                    DateRented=DateTime.Now 
                };
                _context.Rentals.Add(rental);
                movie.NumberAvailable -= 1;
            }
            _context.SaveChanges();
            return Ok();

        }

    }
}