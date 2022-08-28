using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSalesAccounting.Models;

namespace StoreSalesAccounting.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationContext db;

        public EmployeeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> PrintEmployee(string name, DateTime? startDate, DateTime? endDate)
        {
            if (name == null && startDate == null)
            {
                return View(await db.Employees.Where(item => item.Day == DateTime.Today).ToListAsync());
            }
            else if (name != null && startDate == null && endDate == null)
            {
                return View(await db.Employees.Where(item => item.Name == name).ToListAsync());
            }
            else if (name == null && startDate != null && endDate == null)
            {
                return View(await db.Employees.Where(item => item.Day == startDate).ToListAsync());
            }
            else if (name != null && startDate != null && endDate == null)
            {
                return View(await db.Employees.Where(item => item.Name == name
                                                          && item.Day == startDate).ToListAsync());
            }
            else if (name == null && startDate != null && endDate != null)
            {
                return View(await db.Employees.Where(item => item.Day >= startDate
                                                          && item.Day <= endDate).ToListAsync());
            }
            else
            {
                return View(await db.Employees.Where(item => item.Name == name
                                                          && item.Day >= startDate
                                                          && item.Day <= endDate).ToListAsync());
            }
        }

        public IActionResult CreateNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewEmployee(Employee employee)
        {
            employee.Day = DateTime.Today;
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("PrintEmployee");
        }


    }
}
