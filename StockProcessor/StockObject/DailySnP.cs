using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStock
{
    public class DailySnP
    {
        public string TodaysDate { get; set; }

        public float OpeningValue { get; set; }

        public float HighValue { get; set; }

        public float LowValue { get; set; }

        public float CloseValue { get; set; }

        public float AdjClose { get; set; }

        public float Volume { get; set; }

        public IEnumerable<DailySnP> SnpCollection { get; set; }

        public DailySnP()
        {

        }

    }
}
