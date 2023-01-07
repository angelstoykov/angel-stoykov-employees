using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuddiesOnProject.Models.Periods
{
    internal class PeriodWorked
    {
        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int CalculateOverlap(PeriodWorked periodToCompare)
        {
            DateTime a = DateFrom > periodToCompare.DateFrom ? DateFrom : periodToCompare.DateFrom;
            DateTo ??= DateTo = DateTime.Now;
            periodToCompare.DateTo ??= periodToCompare.DateTo = DateTime.Now;
            DateTime b = (DateTime)(DateTo < periodToCompare.DateTo ? DateTo : periodToCompare.DateTo);

            return a < b ? b.Subtract(a).Days : 0;
        }
    }
}
