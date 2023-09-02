using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vizsgafeladat.Entities;
using Vizsgafeladat.Models;

namespace Vizsgafeladat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReportDbContext _context;

        public HomeController(ReportDbContext context)
        {
            _context = context;
        }

        public IActionResult Problemreport()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Problemreport(Report report)
        {
            if (ModelState.IsValid)
            {
                report.ReportDate = DateTime.Now;
                _context.Reports.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction("Confirmation");
            }
            return View(report);
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}