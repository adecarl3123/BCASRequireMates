using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BCASRequireMates.Data;
using BCASRequireMates.Models;
using Microsoft.AspNetCore.Authorization;
using BCASRequireMates.ViewModel;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BCASRequireMates.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingenvironment;
        

        public RequestController(ApplicationDbContext context, IWebHostEnvironment hostingenvironment)
        {
            _hostingenvironment = hostingenvironment;
            _context = context;
            
        }

        // GET

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requests.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }


        
        public IActionResult Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,PaymentReference,Photo, Status")] RequestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string filename = "";
                if (viewModel.Photo != null)
                {
                    // Define the upload folder path and generate a unique filename
                    string uploadFolder = Path.Combine(_hostingenvironment.WebRootPath, "images");
                    filename = Guid.NewGuid().ToString() + "_" + viewModel.Photo.FileName;

                    // Ensure the upload folder exists
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Define the file path and save the file
                    string filePath = Path.Combine(uploadFolder, filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewModel.Photo.CopyToAsync(fileStream);
                    }
                }

                // Retrieve the logged-in user's ID
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                // Create a new request object and map the filename
                Request request = new Request
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber,
                    PaymentReference = viewModel.PaymentReference,
                    Image = filename,
                    AppUserId = userId, // Set the AppUserId as the current user's ID
                    Status = viewModel.Status// Save the filename to the request object
                };

                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }


        
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,PaymentReference, Status")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [Authorize(Roles ="Admin")]
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
