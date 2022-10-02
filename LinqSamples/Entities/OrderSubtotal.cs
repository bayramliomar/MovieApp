using System;
using System.Collections.Generic;

#nullable disable

namespace LinqSamples.Entities
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
