using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DynamicTable.Models
{
    public class BankContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }
    }
}
