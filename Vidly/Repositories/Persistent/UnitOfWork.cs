using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Repositories.Core;

namespace Vidly.Repositories.Persistent
{
    public class UnitOfWork:IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public ICustomerRepository Customers { get; private set; }
        public IMovieRepository Movies { get; private set; }
        public IRentalRepository Rentals { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            //Movies=new MovieRepository()
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        

    }
}