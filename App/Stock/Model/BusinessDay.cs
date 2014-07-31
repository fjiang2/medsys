using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class BusinessDay
    {
        public bool IsBusinessDay(DateTime time)
        {
            switch (time.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    if (time.Hour >= 8 && time.Hour <= 16)
                        return true;
                    break;
            }
            
            return false;
        }
    }
}
