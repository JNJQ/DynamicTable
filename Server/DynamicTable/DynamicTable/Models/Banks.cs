using System;
using System.Collections.Generic;

namespace DynamicTable
{
    public partial class Banks
    {
        public int Id { get; set; }
        public double BestBid { get; set; }
        public double BestOffer { get; set; }
        public string Instrument { get; set; }
    }
}
