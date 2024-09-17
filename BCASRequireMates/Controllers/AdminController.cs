using BCASRequireMates.Data;
using BCASRequireMates.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BCASRequireMates.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        // GET: /Admin/Users
        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }



        // GET: /Admin/EditUser/{id}
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: /Admin/EditUser
        [HttpPost]
        public async Task<IActionResult> EditUser(AppUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Address = model.Address;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Users");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }

        // GET: /Admin/DeleteUser/{id}
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: /Admin/DeleteUser
        [HttpPost]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Users");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("Users");
        }

        ////Request Manage
        // GET: Admin/Requests
        public async Task<IActionResult> Requests()
        {
            var requests = await _context.UserDocumentRequests
                .Include(r => r.Document)
                //.Include(r => r.UserId)
                .ToListAsync();

            return View(requests);
        }

        // POST: Admin/UpdateRequestStatus
        [HttpPost]
        public async Task<IActionResult> UpdateRequestStatus(int id, string status)
        {
            var request = await _context.UserDocumentRequests.FindAsync(id);
            if (request != null)
            {
                request.Status = status;
                _context.Update(request);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Requests));
        }






    }
}
