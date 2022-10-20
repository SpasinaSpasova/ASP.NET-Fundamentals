using NuGet.Common;
using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Models;
using static Watchlist.Data.DataConstants.Movie;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(MovieTitleMax, MinimumLength = MovieTitleMin)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MovieDirectoreMax, MinimumLength = MovieDirectorMin)]
        public string Director { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
