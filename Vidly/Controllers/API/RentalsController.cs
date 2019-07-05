using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Repositories;
using Vidly.Repositories.Persistent;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;
        private UnitOfWork unitOfWork;
        public RentalsController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET api/<controller>
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            int errorCode=unitOfWork.Rentals.CreateNewRentals(rentalDto);
            unitOfWork.Complete();
            if (errorCode == -1)
                return BadRequest();
            return Ok();

        }
    }
}