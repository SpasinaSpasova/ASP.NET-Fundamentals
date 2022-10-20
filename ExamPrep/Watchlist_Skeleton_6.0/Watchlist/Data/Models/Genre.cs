using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.DataConstants.Genre;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GenreNameMax)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
