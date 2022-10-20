using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext watchlistDbContext;

        public MovieService(WatchlistDbContext _watchlistDbContext)
        {
            this.watchlistDbContext = _watchlistDbContext;
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var entity = new Movie()
            {
                ImageUrl = model.ImageUrl,
                Director = model.Director,
                Title = model.Title,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            if (!watchlistDbContext.Movies.Any(m => m.Title == model.Title))
            {
                await watchlistDbContext.Movies.AddAsync(entity);

                await watchlistDbContext.SaveChangesAsync();

            }

        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var movie = await watchlistDbContext.Movies.FirstOrDefaultAsync(x => x.Id == movieId);

            var user = await watchlistDbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            if (movie == null)
            {
                throw new ArgumentException("Invalid movie ID");
            }

            if (!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movie.Id,
                    UserId = user.Id,
                    Movie = movie,
                    User = user
                });

                await watchlistDbContext.SaveChangesAsync();
            }


        }

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            return await watchlistDbContext.Movies.Select(m => new MovieViewModel()
            {
                Id = m.Id,
                ImageUrl = m.ImageUrl,
                Title = m.Title,
                Director = m.Director,
                Rating = m.Rating,
                Genre = m.Genre.Name

            }).ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await watchlistDbContext.Genres.ToListAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await watchlistDbContext.Users
                .Where(x => x.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(u => u.Movie)
                .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UsersMovies.Select(m => new MovieViewModel()
            {
                Id = m.MovieId,
                ImageUrl = m.Movie.ImageUrl,
                Title = m.Movie.Title,
                Director = m.Movie.Director,
                Rating = m.Movie.Rating,
                Genre = m.Movie.Genre.Name

            }).ToList();
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var user = await watchlistDbContext.Users
                .Where(x => x.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

            if (movie != null)
            {
                user.UsersMovies.Remove(movie);
                await watchlistDbContext.SaveChangesAsync();
            }

        }
    }
}
