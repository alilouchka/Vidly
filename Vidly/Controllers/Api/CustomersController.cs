﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Controllers.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers( string query = null) // paramètre optionnel quand je le mets à null
        {                                                                  // le parametre query est utilisé pour le typeahead twitter 

            var customersQuery = _context.Customers.Include(c => c.MembershipType);
            if(!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            return customersQuery
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            
            
        }

        // GET /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer ==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customer);

        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
           // après la création, Un Id sera attribué 
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id), customerDto);

           
        }
        
        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult  UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customerDto,customerInDb); // 2 arguments (source,destination) 
            //customerInDb.Name = customer.Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            // We can use a tool like auto mapper to avoid this lines of updating 

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/customers/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
