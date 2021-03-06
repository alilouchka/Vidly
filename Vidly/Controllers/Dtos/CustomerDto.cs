﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Controllers.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required] //data annotation 
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public DateTime? Birthdate { get; set; }
        public byte MembershipTypeId { get; set; }
        public MemebershipTypeDto MembershipType { get; set; } // Il faut exactement avoir le meme nom du modèle ('MembershipType')
    }
}