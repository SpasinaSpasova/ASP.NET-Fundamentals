using Library.Data.Models;
using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.Book;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(BookTitleMax, MinimumLength = BookTitleMin)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookAuthorMax, MinimumLength = BookAuthorMin)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMax, MinimumLength = BookDescriptionMin)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.00", "10.00", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
