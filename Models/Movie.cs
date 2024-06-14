using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        //id field is for the primary key in db
        public int Id { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal? Price { get; set; }
    }
}
