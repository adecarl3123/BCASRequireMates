//using BCASRequireMates.Data;
//using BCASRequireMates.Models;
//using BCASRequireMates.ViewModel;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace BCASRequireMates.Controllers
//{
//    public class UserRequestController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public UserRequestController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: DocumentRequests/Create
//        public IActionResult Create()
//        {
//            // Populate view model with necessary data (e.g., list of documents)
//            var viewModel = new UserRequestDocumentViewModel
//            {
//                Documents = _context.Document.ToList()
//            };
//            return View(viewModel);
//        }

//        // POST: DocumentRequests/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(UserRequestDocumentViewModel viewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                var userDocumentRequest = new UserDocumentRequest
//                {
//                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
//                    DocumentId = viewModel.SelectedDocumentId,
//                    RequestDate = DateTime.Now,
//                    Status = "Pending"
//                };

//                _context.Add(userDocumentRequest);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index)); // Redirect to a confirmation page or list of requests
//            }

//            // If model state is not valid, reload the view model
//            viewModel.Documents = _context.Document.ToList();
//            return View(viewModel);
//        }
//    }
//}
