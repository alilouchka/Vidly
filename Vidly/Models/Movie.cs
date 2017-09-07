
using System;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        public short NumberInStock { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}