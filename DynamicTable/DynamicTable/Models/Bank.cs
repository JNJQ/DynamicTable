using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string Instrument { get; set; }
        public int BestBid { get; set; }
        public int BestOffer { get; set; }
    }
}
