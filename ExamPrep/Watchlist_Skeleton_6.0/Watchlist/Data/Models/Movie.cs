using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Watchlist.Data.DataConstants.Movie;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(MovieTitleMax)]
        public string Title { get; set; }

        [Required]
        [StringLength(MovieDirectoreMax)]
        public string Director { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();

    }
}
