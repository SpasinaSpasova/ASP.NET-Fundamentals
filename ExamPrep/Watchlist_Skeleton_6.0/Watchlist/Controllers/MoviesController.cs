using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Models;

namespace Watchlist.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        public MoviesController(IMovieService _movieService)
        {
            this.movieService = _movieService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await movieService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddMovieViewModel()
            {
                Genres = await movieService.GetGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await movieService.AddMovieAsync(model);

                return RedirectToAction("All", "Movies");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong.");

                return View(model);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await movieService.AddMovieToCollectionAsync(movieId, userId);

            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<MovieViewModel> model;

            try
            {
                model = await movieService.GetWatchedAsync(userId);

            }
            catch (Exception)
            {

                throw;
            }

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await movieService.RemoveMovieFromCollectionAsync(movieId, userId);

            return RedirectToAction(nameof(Watched));
        }

    }
}
