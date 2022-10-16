 using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public HomeController(TaskBoardAppDbContext context)
        {
            this.data = context;
        }

        /// <summary>
        /// Gets all boards name from DB and create HomeBoardModel with count of tasks in current board with vurrent board name
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            var taskBoards = this.data.Boards.Select(b => b.Name)
                .Distinct();

            var tasksCounts = new List<HomeBoardModel>();

            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = this.data.Tasks.Where(t => t.Board.Name == boardName).Count();

                tasksCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });

            }

            /// <summary>
            /// Gets a currentUser tasks count and create HomeViewModel where we sets users tasks counts, all tasks count in DB and all boards with current tasks count
            /// </summary>
            /// <returns></returns>
            var userTasksCount = -1;
            
            if (this.User.Identity.IsAuthenticated)
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                userTasksCount = this.data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = this.data.Tasks.Count(),
                BoardsWithTasksCount = tasksCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }
        
    }
}