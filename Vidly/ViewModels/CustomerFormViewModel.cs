using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        // IEnumerable permet d'avoir le parametre 
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        // Dans le cas ou on a plusieurs parametre plus complexes on peut rajouter des parametres dans le ViewModel autres que les Models


    }
}