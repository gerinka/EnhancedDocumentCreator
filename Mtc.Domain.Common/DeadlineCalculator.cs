using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtc.Domain.Common
{
    public static class DeadlineCalculator
    {

        public static DateTime CalculateDeadline(DateTime documentDeadline, int previousTasks, int totalContentCount, int cycle)
        {
            var timePerTask = (documentDeadline - DateTime.UtcNow).TotalDays / totalContentCount;
            return DateTime.UtcNow.AddDays((previousTasks + 1) * timePerTask);
        }

        public static int CalculateMaxCycles(DateTime documentDeadline, int totalContentCount){
            return (int)Math.Floor((documentDeadline - DateTime.UtcNow).TotalDays /(2* totalContentCount)) + 1;
            
        }
    }
}
