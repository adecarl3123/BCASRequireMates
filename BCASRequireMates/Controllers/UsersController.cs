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

namespace BCASRequireMates.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingenvironment;
        

        public UsersController(ApplicationDbContext context, IWebHostEnvironment hostingenvironment)
        {
            _hostingenvironment = hostingenvironment;
            _context = context;
            
        }

        // GET
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubmitRequest.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitRequest = await _context.SubmitRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submitRequest == null)
            {
                return NotFound();
            }

            return View(submitRequest);
        }

        
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,PaymentReference,Photo")] RequestViewModel viewModel)
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

                // Create a new request object and map the filename
                SubmitRequest request = new SubmitRequest
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber,
                    PaymentReference = viewModel.PaymentReference,
                    Image = filename // Save the filename to the request object
                };

                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }


        // GET: Users/Edit/5
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitRequest = await _context.SubmitRequest.FindAsync(id);
            if (submitRequest == null)
            {
                return NotFound();
            }
            return View(submitRequest);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,PaymentReference")] SubmitRequest submitRequest)
        {
            if (id != submitRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submitRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmitRequestExists(submitRequest.Id))
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
            return View(submitRequest);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submitRequest = await _context.SubmitRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submitRequest == null)
            {
                return NotFound();
            }

            return View(submitRequest);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submitRequest = await _context.SubmitRequest.FindAsync(id);
            if (submitRequest != null)
            {
                _context.SubmitRequest.Remove(submitRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmitRequestExists(int id)
        {
            return _context.SubmitRequest.Any(e => e.Id == id);
        }
    }
}
