using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Controllers
{
    public class HomeController : Controller
    {
        BanksDBContext _db;
        public HomeController(BanksDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public JsonResult Start()
        {
            return Json(_db.Banks);
        }

        [HttpGet]
        public async Task<JsonResult> IndexAsync()
        {
            foreach (var bank in _db.Banks)
            {
                var bk = await _db.Banks.FirstOrDefaultAsync(x => x.Id == bank.Id);
                bk.BestBid = GetRand();
                bk.BestOffer = GetRand();

                _db.Entry(bk).State = EntityState.Modified;
            }

            await _db.SaveChangesAsync();

            return Json(_db.Banks);
        }

        private double GetRand()
        {
            int min = 100;
            int max = 1000;
            return Math.Round((new Random()).NextDouble() % (max - min) + min, 2);
        }
    }
}
