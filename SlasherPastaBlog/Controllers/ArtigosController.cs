using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SlasherPastaBlog.Data;
using SlasherPastaBlog.Models;

namespace SlasherPastaBlog.Controllers
{
    public class ArtigosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager; //Allows me to get info about current logged user

        private readonly ILogger<ArtigosController> _logger;

        public ArtigosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<ArtigosController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: Artigos
        public async Task<IActionResult> Index(string searchString, int? year, string month)
        {
            IQueryable<Artigos> artigos = _context.Artigos.Include(a => a.ApplicationUser); ;

            if (User.IsInRole("Admin") || User.IsInRole("RatingM"))
            {
                // See all articles
                artigos = artigos.Include(a => a.ApplicationUser); ;
            }
            else if (User.IsInRole("RatingT"))
            {
                // See only T and E rated articles
                artigos = artigos.Where(a => a.Role == "RatingT" || a.Role == "RatingE")
                    .Include(a => a.ApplicationUser); ;
            }
            else if (User.IsInRole("RatingE"))
            {
                // See only E rated articles
                artigos = artigos.Where(a => a.Role == "RatingE")
                    .Include(a => a.ApplicationUser); ;
            }

            // Apply date filter if year and month are specified
            if (year.HasValue)
            {
                artigos = artigos.Where(s => s.DataPublicacao.Year == year.Value);
                if (!String.IsNullOrEmpty(month))
                {
                    var monthNumber = DateTime.ParseExact(month, "MMMM", null).Month;
                    artigos = artigos.Where(s => s.DataPublicacao.Month == monthNumber)
                        .Include(a => a.ApplicationUser); ;
                }

                ViewBag.Year = year;
                ViewBag.Month = month;
            }

            // Apply search string filter
            if (!String.IsNullOrEmpty(searchString))
            {
                artigos = artigos.Where(s => s.Titulo.Contains(searchString))
                    .Include(a => a.ApplicationUser); ;
            }

            ViewBag.YearsAndMonths = await GetYearsAndMonths();

            return View(await artigos.ToListAsync());
        }


        //Gets the dates/months in which articles were published
        //to pass to the aside trough the ViewBag
        private async Task<Dictionary<int, List<string>>> GetYearsAndMonths()
        {
            var allArticles = await _context.Artigos.ToListAsync();

            var yearList = allArticles.Select(a => a.DataPublicacao.Year)
                                      .Distinct()
                                      .OrderByDescending(y => y)
                                      .ToList();

            var monthList = new Dictionary<int, List<string>>();
            foreach (var year in yearList)
            {
                var monthsInYear = allArticles.Where(a => a.DataPublicacao.Year == year)
                                              .Select(a => a.DataPublicacao.ToString("MMMM"))
                                              .Distinct()
                                              .OrderByDescending(m => DateTime.ParseExact(m, "MMMM", null).Month)
                                              .ToList();
                monthList[year] = monthsInYear;
            }

            return monthList;
        }

        // GET: Artigos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artigos == null)
            {
                return NotFound();
            }

            var artigos = await _context.Artigos
                                        .Include(a => a.Ratings)
                                        .Include(a => a.ApplicationUser)
                                        .FirstOrDefaultAsync(m => m.Id == id);

            if (artigos == null)
            {
                return NotFound();
            }

            return View(artigos);
        }

        // GET: Artigos/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artigos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Conteudo,Role,ApplicationUserId")] Artigos artigos)
        {
            //Issue with appUSer that causes modelState to be invalid. Removed!
            //Dont need viewModel this way
            ModelState.Remove("ApplicationUser");
            ModelState.Remove("Ratings");

            artigos.DataPublicacao = DateTime.Now;
            if (ModelState.IsValid)
            {
                // Get the currently logged-in user
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }

                // Set the ApplicationUserId to the current user's ID
                artigos.ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _context.Add(artigos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }
            return View(artigos);
        }

        // GET: Artigos/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artigos == null)
            {
                return NotFound();
            }

            var artigos = await _context.Artigos
                                        .Include(a => a.Ratings)
                                        .FirstOrDefaultAsync(a => a.Id == id);

            if (artigos == null)
            {
                return NotFound();
            }
            return View(artigos);
        }

        // POST: Artigos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Conteudo,DataPublicacao,Role,ApplicationUserId")] Artigos artigos)
        {

            ModelState.Remove("ApplicationUser");
            ModelState.Remove("Ratings");

            if (id != artigos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artigos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtigosExists(artigos.Id))
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
            return View(artigos);
        }

        // GET: Artigos/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artigos == null)
            {
                return NotFound();
            }

            var artigos = await _context.Artigos
                                        .Include(a => a.Ratings)
                                        .Include(a => a.ApplicationUser)
                                        .FirstOrDefaultAsync(m => m.Id == id);

            if (artigos == null)
            {
                return NotFound();
            }

            return View(artigos);
        }

        // POST: Artigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artigos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Artigos'  is null.");
            }
            var artigos = await _context.Artigos.FindAsync(id);
            if (artigos != null)
            {
                _context.Artigos.Remove(artigos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtigosExists(int id)
        {
            return (_context.Artigos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> RateArtigo(ArtigoRatingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var rating = new ArtigoRatings
                {
                    ArtigoId = model.ArtigoId,
                    Rating = model.Rating,
                    RaterId = userId
                };

                _context.ArtigoRatings.Add(rating);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = model.ArtigoId });
            }

            return View(model);
        }
    }
}
