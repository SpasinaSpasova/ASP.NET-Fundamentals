using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            this.context = _context;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var entity = new Book()
            {
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Author = model.Author,
                Title = model.Title,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            if (!context.Books.Any(b => b.Title == model.Title))
            {
                await context.Books.AddAsync(entity);

                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            var user = await context.Users.Where(u => u.Id == userId)
                .Include(b => b.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            if (book == null)
            {
                throw new ArgumentException("Invalid book ID");
            }

            if (!user.ApplicationUsersBooks.Any(b => b.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUserId = userId,
                    Book = book,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            return await context.Books.Select(b => new BookViewModel()
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Author = b.Author,
                ImageUrl = b.ImageUrl,
                Rating = b.Rating,
                Category = b.Category.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<BookViewModel>> GetMineAsync(string userId)
        {
            var user = await context.Users.Where(x => x.Id == userId).Include(b => b.ApplicationUsersBooks).ThenInclude(b => b.Book).ThenInclude(c => c.Category).FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.ApplicationUsersBooks.Select(b => new BookViewModel()
            {
                Id = b.BookId,
                ImageUrl = b.Book.ImageUrl,
                Title = b.Book.Title,
                Author = b.Book.Author,
                Description = b.Book.Description,
                Rating = b.Book.Rating,
                Category = b.Book.Category.Name
            }).ToList();
        }

        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users.Where(u => u.Id == userId).
                Include(b => b.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = user.ApplicationUsersBooks.FirstOrDefault(b => b.BookId == bookId);

            if (book != null)
            {
                user.ApplicationUsersBooks.Remove(book);
                await context.SaveChangesAsync();
            }
        }
    }
}
