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
using Vidly.Repositories.Persistent;
using Vidly.Repositories.Core;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        

        public CustomersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
 //           this.unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        /*protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }*/
        // GET /api/customers
        
        public IHttpActionResult GetCustomers(string query=null)
        {

            return Ok(unitOfWork.Customers.GetCustomersWithQuery(query));
        } 
        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = unitOfWork.Customers.GetCustomerWithId(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
        // POST /api/customers
        [System.Web.Http.HttpPost]
        [Route("api/Customers/Create")]
        //if you dont want to mention HttpPost then name the function with prefix Post
        public IHttpActionResult CreateCustomer (CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            int customerId = unitOfWork.Customers.CreateCustomer(customerDto);

            unitOfWork.Complete();
            return Created(new Uri(Request.RequestUri+"/"+customerId),customerDto);
        } 
        // PUT /api/customers/1
        [System.Web.Http.HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            unitOfWork.Customers.UpdateCustomer(id, customerDto);
            unitOfWork.Complete();
        }

        // DELETE /api/customers/1
        [System.Web.Http.HttpDelete]
        public void DeleteCustomer(int id)
        {
            unitOfWork.Customers.DeleteCustomer(id);
            unitOfWork.Complete();
        }
    }
}