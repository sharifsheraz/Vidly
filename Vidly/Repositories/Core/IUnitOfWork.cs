using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Repositories.Core
{
    public interface IUnitOfWork: IDisposable
    {
        ICustomerRepository Customers { get; }
        IMovieRepository Movies { get; }
        IRentalRepository Rentals { get; }

       int Complete();
    }
}