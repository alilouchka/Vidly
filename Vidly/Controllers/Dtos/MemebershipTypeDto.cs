using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Controllers.Dtos
{
    public class MemebershipTypeDto
    {
        public byte Id { get; set; } 
        public string Name { get; set; }
        //Ce n'est pas la pein de rajotuer les autres champs , car si besoin on envoie une requete en utilisant l'Id et avoir des détails
        // Il faut toujours laisser les Dto "Lights" ! 
    }
}