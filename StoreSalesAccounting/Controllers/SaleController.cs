using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSalesAccounting.Models;

namespace StoreSalesAccounting.Controllers
{
    public class SaleController : Controller
    {
        ApplicationContext db;

        public SaleController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> PrintSales(string name, DateTime? startDate, DateTime? endDate)
        {
            if (name == null && startDate == null)
            {
                return View(await db.Sales.Include(item => item.Employee).Where(item => item.Day == DateTime.Today).ToListAsync());
            }
            else if (name != null && startDate == null && endDate == null)
            {
                return View(await db.Sales.Include(item => item.Employee).Where(item => item.Employee.Name == name).ToListAsync());
            }
            else if (name == null && startDate != null && endDate == null)
            {
                return View(await db.Sales.Include(item => item.Employee).Where(item => item.Day == startDate).ToListAsync());
            }
            else if (name != null && startDate != null && endDate == null)
            {
                return View(await db.Sales.Include(item => item.Employee).Where(item => item.Employee.Name == name
                                                          && item.Day == startDate).ToListAsync());
            }
            else if (name == null && startDate != null && endDate != null)
            {
                return View(await db.Sales.Include(item => item.Employee).Where(item => item.Day >= startDate
                                                          && item.Day <= endDate).ToListAsync());
            }
            else
            {
                return View(await db.Sales.Include(item => item.Employee).Where(item => item.Employee.Name == name
                                                          && item.Day >= startDate
                                                          && item.Day <= endDate).ToListAsync());
            }
        }

        public IActionResult NewEnrollment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewEnrollment(string name, string product, string payment, int paymentSum, string note)
        {
            if (name != null && product != null && paymentSum != 0)
            {
                var staff = db.Employees.FirstOrDefault(item => item.Name == name
                                                                 && item.Day == DateTime.Today);
                if (staff != null)
                {
                    var sale = new Sale
                    {
                        EmployeeId = staff.Id,
                        ProductName = product,
                        PaymentMethod = payment,
                        SaleAmount = paymentSum,
                        Day = DateTime.Today,
                        Note = note,
                    };

                    switch (payment)
                    {
                        case "Наличные":
                            staff.Cash += paymentSum;
                            staff.TotalRevenue = staff.Cash + staff.NonCash + staff.OnlineCash;
                            break;

                        case "Безналичные":
                            staff.NonCash += paymentSum;
                            staff.TotalRevenue = staff.Cash + staff.NonCash + staff.OnlineCash;
                            break;

                        case "Перевод СБП":
                            staff.OnlineCash += paymentSum;
                            staff.TotalRevenue = staff.Cash + staff.NonCash + staff.OnlineCash;
                            break;

                        default:
                            break;
                    }

                    db.Sales.Add(sale);
                    db.Employees.Update(staff);
                }

                db.SaveChanges();
                return RedirectToAction("PrintSales");
            }
            else
            {
                return View();
            }
        }
    }
}
