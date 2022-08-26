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

        public IActionResult CreateNewRepair()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewRepair(Repair repair)
        {
            repair.RepairStartDate = DateTime.Today;
            repair.GiveAway = "Нет";
            db.Repairs.Add(repair);
            await db.SaveChangesAsync();

            return RedirectToAction("RepairIndex");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Repair? repair = await db.Repairs.FirstOrDefaultAsync(r => r.RepairId == id);
                if (repair != null) 
                    return View(repair);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Repair repair, int? id)
        {
            Repair? repairId = await db.Repairs.FirstOrDefaultAsync(r => r.RepairId == id);

            repair.ReceivingEmployee = repairId.ReceivingEmployee;
            repair.RepairStartDate = repairId.RepairStartDate;
            repair.ClientNumber = repairId.ClientNumber;
            repair.ClientName = repairId.ClientName;
            repair.GuitarCase = repairId.GuitarCase;
            repair.GiveAway = repairId.GiveAway;
            repair.RepairEndDate = repairId.RepairEndDate;
            repair.MusicalInstrument = repairId.MusicalInstrument;

            db.Repairs.Add(repair);
            db.Repairs.Remove(repairId);
            await db.SaveChangesAsync();
            return RedirectToAction("RepairIndex");
        }

        public async Task<IActionResult> IssueTool(int id)
        {
            Repair? repair = await db.Repairs.FirstOrDefaultAsync(r => r.RepairId == id);
            if (repair != null)
            {
                repair.GiveAway = "Да";

                db.Repairs.Update(repair);
            }

            await db.SaveChangesAsync();
            return RedirectToAction("RepairIndex");
        }
    }
}
