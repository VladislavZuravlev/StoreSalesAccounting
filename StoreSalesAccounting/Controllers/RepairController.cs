using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreSalesAccounting.Models;

namespace StoreSalesAccounting.Controllers
{
    public class RepairController : Controller
    {
        ApplicationContext db;
        public RepairController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> RepairIndex()
        {
            return View(await db.Repairs.ToListAsync());
        }

        public async Task<IActionResult> CreateNewRepair()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewRepair(Repair repair)
        {
            repair.RepairStartDate = DateTime.Today;
            repair.GiveAway = false;
            db.Repairs.Add(repair);
            await db.SaveChangesAsync();

            return View("RepairIndex");
        }

    }
}
