using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSalesAccounting.Models;

namespace StoreSalesAccounting.Controllers
{
    public class EmployeeController : Controller
    {
        public string? Name { get; set; }
        public string? Product { get; set; }
        public int Deposit { get; set; }
        public bool Cash { get; set; }
        public bool NonCash { get; set; }
        public bool OnlineCash { get; set; }


        ApplicationContext db;

        public EmployeeController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> PrintEmployee(string name, DateTime? startDate, DateTime? endDate)
        {
            if (name == null && startDate == null)
            {
                return View(await db.Employees.Where(item => item.EmployeeDay == DateTime.Today).ToListAsync());
            }
            else if (name != null && startDate == null && endDate == null)
            {
                return View(await db.Employees.Where(item => item.Name == name).ToListAsync());
            }
            else if (name == null && startDate != null && endDate == null)
            {
                return View(await db.Employees.Where(item => item.EmployeeDay == startDate).ToListAsync());
            }
            else if (name != null && startDate != null && endDate == null)
            {
                return View(await db.Employees.Where(item => item.Name == name
                                                          && item.EmployeeDay == startDate).ToListAsync());
            }
            else if (name == null && startDate != null && endDate != null)
            {
                return View(await db.Employees.Where(item => item.EmployeeDay >= startDate
                                                          && item.EmployeeDay <= endDate).ToListAsync());
            }
            else
            {
                return View(await db.Employees.Where(item => item.Name == name
                                                          && item.EmployeeDay >= startDate
                                                          && item.EmployeeDay <= endDate).ToListAsync());
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            employee.EmployeeDay = DateTime.Today;
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("PrintEmployee");
        }


        public IActionResult NewEnrollment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewEnrollment(string name, string product, int deposit, bool cash, bool nonCash, bool onlineCash)
        {
            if (name != null)
            {
                var employee = db.Employees.FirstOrDefault(item => item.EmployeeDay == DateTime.Today && item.Name == name);

                if (employee != null)
                {
                    if (cash)
                        employee.EmployeeCash += deposit;
                    else if (nonCash)
                        employee.EmployeeNonCash += deposit;
                    else if (onlineCash)
                        employee.EmployeeOnlineCash += deposit;

                    if (product != null)
                        employee.Product += $"{product}, ";

                    employee.EmployeeTotalRevenue = employee.EmployeeCash + employee.EmployeeNonCash + employee.EmployeeOnlineCash;

                    db.Employees.Update(employee);
                }
            }

            await db.SaveChangesAsync();
            return RedirectToAction("PrintEmployee");
        }



    }
}
