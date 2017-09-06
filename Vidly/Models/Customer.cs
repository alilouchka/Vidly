using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required] //data annotation 
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        
        //Navigation property  (association)
        public MembershipType MembershipType { get; set; }

        //Pour optimisation on peut rajouter une propriété de foreignkey 
        public byte MembershipTypeId { get; set; }

    }
}