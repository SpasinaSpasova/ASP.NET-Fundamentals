using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.DataConstants.Movie;

namespace Watchlist.Models
{
    public class MovieViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(MovieTitleMax,MinimumLength =MovieTitleMin)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MovieDirectoreMax, MinimumLength = MovieDirectorMin)]
        public string Director { get; set; } = null!;

        [Required]
        [Range(typeof(decimal),"0.00","10.00",ConvertValueInInvariantCulture =true)]
        public decimal Rating { get; set; }

        [Required]
        public string Genre { get; set; } = null!;

    }
}
