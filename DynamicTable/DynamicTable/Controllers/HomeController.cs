using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DynamicTable.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace DynamicTable.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private BankContext db;
        public HomeController(BankContext context)
        {
            db = context;

            if (!db.Banks.Any())
            {
                var instruments = new string[]
                    {
                    #region instruments
                    "SBRF", "TINKOFF", "VTB", "GAZPROMBANK",
                    "ALFA-BANK", "RSHB", "ROSBANK",
                    "RAIFFEISEN", "OPEN", "MKB"
                    #endregion
                    };
                foreach(var instr in instruments)
                {
                    var bank = new Bank()
                    {
                        Instrument = instr,
                        BestBid = 0,
                        BestOffer = 0
                    };
                    db.Banks.Add(bank);
                }
                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Banks.ToListAsync());
        }

        [HttpGet]
        public async Task<IEnumerable<Bank>> Get()
        {
            foreach (var bank in db.Banks)
            {
                var bk = await db.Banks.FirstOrDefaultAsync(x => x.Id == bank.Id);
                bk.BestBid = GetRand();
                bk.BestOffer = GetRand();

                db.Entry(bk).State = EntityState.Modified;
            }

            await db.SaveChangesAsync();

            return db.Banks;
        }

        private int GetRand()
        {
            int min = 100;
            int max = 1000;
            return (new Random()).Next() % (max - min) + min;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
