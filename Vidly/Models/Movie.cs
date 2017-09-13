
using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Added date")]
        public DateTime AddedDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number in stock")]
        public short NumberInStock { get; set; }


        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
    }
}