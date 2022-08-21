using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSalesAccounting.Models;


namespace StoreSalesAccounting.Controllers
{
    public class StoreRevenueController : Controller
    {

        ApplicationContext db;
        public StoreRevenueController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> PrintStoreSales(DateTime? startDate, DateTime? endDate)
        {
            CreateGeneralSales();
            if (startDate == null || startDate == DateTime.MinValue)
            {
                return View(await db.StoreRevenues.ToListAsync());
            }
            else if (endDate == null || endDate == DateTime.MinValue)
            {
                return View(await db.StoreRevenues.Where(item => item.Day == startDate).ToListAsync());
            }
            else
            {
                return View(await db.StoreRevenues.Where(item => item.Day >= startDate && item.Day <= endDate).ToListAsync());
            }

        }

        [HttpPost]
        public async Task<IActionResult> MyList(DateTime? startdate)
        {
            return View(await db.StoreRevenues.Where(item => item.Day == startdate).ToListAsync());
        }

        private void CreateGeneralSales()
        {
            StoreRevenue? storeRevenue = db.StoreRevenues.FirstOrDefault(item => item.Day == DateTime.Today);
            StoreRevenue newStore = new StoreRevenue();

            foreach (var item in db.Employees.ToList())
            {
                if (item.EmployeeDay == DateTime.Today)
                {
                    newStore.StoreCash += item.EmployeeCash;
                    newStore.StoreNonCash += item.EmployeeNonCash;
                    newStore.StoreOnlineCash += item.EmployeeOnlineCash;
                }
            }
            newStore.StoreTotalRevenue = newStore.StoreCash + newStore.StoreNonCash + newStore.StoreOnlineCash;
            newStore.Day = DateTime.Today;

            if (storeRevenue == null)
            {
                db.StoreRevenues.Add(newStore);
                db.SaveChanges();
            }
            else
            {
                storeRevenue.StoreCash = newStore.StoreCash;
                storeRevenue.StoreNonCash = newStore.StoreNonCash;
                storeRevenue.StoreOnlineCash = newStore.StoreOnlineCash;
                storeRevenue.StoreTotalRevenue = storeRevenue.StoreCash + storeRevenue.StoreNonCash + storeRevenue.StoreOnlineCash;
                storeRevenue.Day = DateTime.Today;
                db.StoreRevenues.Update(storeRevenue);
                db.SaveChanges();
            }
        }


    }
}
