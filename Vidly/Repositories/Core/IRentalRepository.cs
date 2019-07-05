using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Repositories.Core
{
    public interface IRentalRepository: IRepository<Rental>
    {
        int CreateNewRentals(NewRentalDto newRentalDto);

    }
}