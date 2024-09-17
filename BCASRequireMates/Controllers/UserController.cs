using BCASRequireMates.Data;
using BCASRequireMates.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCASRequireMates.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult StudentDashboard()
        //{
        //    return View();
        //}

        public async Task<IActionResult> UserDashboard()
        {
            // Fetch documents from the database
            var documents = await _context.Document.ToListAsync();

            // Create ViewModel with converted documents
            var viewModel = new DocumentVM
            {
                Documents = documents.Select(doc => new DocumentItem
                {
                    DocumentName = doc.Name,
                    Price = doc.Price
                }).ToList()
            };

            // Pass ViewModel to the view
            return View(viewModel);
        }
    }
}
