using BCASRequireMates.Data;
using BCASRequireMates.Models;
using BCASRequireMates.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCASRequireMates.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        // GET: User/Requests
        [HttpGet]
        public async Task<IActionResult> MyRequests()
        {
            // Get the logged-in user's Id
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized(); // Handle if the user is not logged in
            }

            // Fetch the user's requests
            var userRequests = await _context.Requests
                .Where(r => r.AppUserId == int.Parse(userId)) // Assuming Request has a UserId field
                .ToListAsync();

            return View(userRequests); // Pass the view model to the view
        }
    }
}
