using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Controllers.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public NewRentalsController()
        {
            _dbContext = new ApplicationDbContext();
        }

     
        // GET  /api/rentals 
        public IEnumerable<Rental> GetRentals()
        {
            return _dbContext.Rentals.ToList();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {





            var movies = _dbContext.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id));

            var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == newRentalDto.CustomerId);
            if (customer == null || movies == null)
                return BadRequest();
            
                foreach (var movie in movies)
                {
                if (movie.NumberAvailable > 0)
                {
                    movie.NumberAvailable--;
                    var newRental = new Rental { Customer = customer, Movie = movie, DateRented = DateTime.Now };
                    _dbContext.Rentals.Add(newRental);

                }
                }
            

            _dbContext.SaveChanges();

            return Ok();  // J'ai pas fait de Created Result car j'ai créé plusieurs ressources en interne .. j'ai pas d'url pour montrer au client la ressource qu'il a créée
          
        }


    }
}
