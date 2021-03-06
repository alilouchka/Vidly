﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Controllers.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        [Range(1, 20)]
        public short NumberInStock { get; set; }
       
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public short NumberAvailable { get; set; }

    }
}