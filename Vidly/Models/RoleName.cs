using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    // Class pour éviter les magic strings des nom de Roles 
    public static class RoleName
    {
        public const string CanManageMovies = "CanManageMovies";
    }
}