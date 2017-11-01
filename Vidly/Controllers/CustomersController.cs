using System.Collections.Generic;
using System.Data.Entity;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Dispose is called when we finish using Context 
        //The Dispose method leaves the Context in an unusable state. After calling Dispose,
        //you must release all references to the Context so the garbage collector can reclaim the memory that the Context was occupying. 
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            // Remarque : l'action New permet d'ajouter un nouveau modèle mais elle permet aussi de le modifier
            //
            var membershipTypes = _context.MemebershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        public ViewResult Index()
        {
            // var customers = GetCustomers();
         //   var customers = _context.Customers.Include(c => c.MembershipType).ToList();   // this instruction will not query the db , we neet to use an iterator in the ViewPage or to use toList() method 
            return View();
        }

        public ActionResult Details(int id)
        {
            
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        
 
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }


        /// <summary>
        /// Model Binding : 
        /// On appelle cette opération le Model Binding, elle sert à passer les valuers des paramètres dans l'input de l'action 
        /// qu'on peut tracker dans (Form Data): inspecter élément du navigateur -> Network -> Nom de l'action 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        // To be sure that our action is called when we have an HTTP Post
        [HttpPost]
        public ActionResult Save(Customer customer) // On peut meme utiliser Customer customer comme input, asp MVC assemble inteligemment les parametres dans le meme objet
        {
              if(customer.Id ==0 ) // Dans le cas où on créer a nouveau customer (il faut pas oublier de rajouter l'Id form en Hidden dans la vue
              _context.Customers.Add(customer);
              else
              {
                  var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Method to Update a model in database (Official MVC ASP .net method) 
                //this function is based of 'key' / 'value' method
                //Inconvenient : cette méthode contient des trous de sécurité , car elle est basée sur (clé ,valeur) 
                // un pirate peut manipuler le format de donnée et modifier plus de paramètres ...
                // Une solution est de rajouter un parametre pour préciser le nom des parametres à modifier par contre si on change le nom de la variabe un jour , il faut le remodifier dans
                // la fonction et c'est un problème bloquant pour le refactoring 

                //TryUpdateModel(customerInDb,"",new string[]{"Name","BirthDate"});


                //La meilleure méthode est de faire la mapping (parametre par parametre)
                //Todo: A voir Mapper.map(.... ) pour optimiser le code 
               
                  customerInDb.Name = customer.Name;
                  customerInDb.Birthdate = customer.Birthdate;

                

              }


          

            _context.SaveChanges();
           

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MemebershipTypes

            };
            // Charger la vue 'New' , sinon il cherchera la vue 'Edit' qui n'existe pas
            return View("CustomerForm",viewModel);
        }
    }
}