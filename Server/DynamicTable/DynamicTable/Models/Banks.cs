using System;
using System.Collections.Generic;

namespace DynamicTable
{
    public partial class Banks
    {
        public int Id { get; set; }
        public int BestBid { get; set; }
        public int BestOffer { get; set; }
        public string Instrument { get; set; }
    }
}
