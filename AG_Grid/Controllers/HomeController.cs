using AG_Grid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AG_Grid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeDbContext _context;

        public HomeController(ILogger<HomeController> logger, EmployeeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowData()
        {
            var emp = _context.Employees.OrderBy(x => x.Id).ToList();
            return Json(emp);
        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
                return Redirect("Index");
            }
            TempData["error"] = "*All values are required.";
            return RedirectToAction("Index");
        }

        public IActionResult Update([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var data = _context.Employees.Find(id);
            if (data != null)
            {
                _context.Employees.Remove(data);
                _context.SaveChanges();
            }

            var emp = _context.Employees.OrderBy(x => x.Id).ToList();
            return Json(emp);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
