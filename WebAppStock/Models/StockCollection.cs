using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStock.Models
{
    public class StockCollection
    {
        public IEnumerable<StockItem> allStocks { get; set; }

        public string[] Xaxis { get; set; }

        public float[] Yaxis { get; set; }
    }
}
