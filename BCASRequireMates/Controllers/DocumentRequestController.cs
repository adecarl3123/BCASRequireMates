using BCASRequireMates.Data;
using BCASRequireMates.Models;
using BCASRequireMates.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BCASRequireMates.Controllers
{
    public class DocumentRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

       
       

        public IActionResult SubmitRequest()
        {
            // Initialize the view model, e.g., fetching available documents
            var viewModel = new DocumentRequest
            {
                AvailableDocuments = _context.Document.Select(doc => new DocumentItem
                {
                    DocumentId = doc.Id,
                    DocumentName = doc.Name,
                    Price = doc.Price
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SubmitRequest(DocumentRequest model)
        {
            if (ModelState.IsValid)
            {
                // Calculate total price based on selected documents and quantity
                model.TotalPrice = model.AvailableDocuments.Sum(doc => doc.Price * doc.Quantity);

                // Handle image file and save data
                //if (model.Image != null)
                //{
                //    var filePath = Path.Combine("wwwroot/uploads", model.Image.FileName);
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        model.Image.CopyTo(stream);
                //    }
                //}

                // Save the request to the database (not shown in this code snippet)

                return RedirectToAction("Success");
            }

            return View("Index");
        }

        public IActionResult Success()
        {
            return View("User", "UserDashboard");
        }
    }

}
