using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
using AutoMapper.QueryableExtensions;
using Vidly.Repositories;
using Vidly.Repositories.Core;

namespace Vidly.Repositories.Persistent
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context ): base(context)
        {

        }
        public IEnumerable<CustomerDto> GetCustomersWithQuery(string query = null)
        {
            var customersQuery = VidlyContext.Customers.Include(c=> c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return customerDtos;

        }
        public CustomerDto GetCustomerWithId(int id)
        {
            var customer = VidlyContext.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return null;
            return Mapper.Map<Customer,CustomerDto>(customer);
        }
        public int CreateCustomer(CustomerDto customerDto)
        {
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            VidlyContext.Customers.Add(customer);
            //VidlyContext.SaveChanges();
            customerDto.Id = customer.Id;
            return customer.Id;
        }
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = VidlyContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            customerInDb.Id = id;
            //VidlyContext.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var customerInDb = VidlyContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            VidlyContext.Customers.Remove(customerInDb);
            //VidlyContext.SaveChanges();

        }
        public ApplicationDbContext VidlyContext
        {
            get { return Context as ApplicationDbContext; }
        }

    }
}