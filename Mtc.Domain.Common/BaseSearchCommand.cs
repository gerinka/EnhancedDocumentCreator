using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edc.Domain.Common
{
    public class BaseSearchCommand<T> where T : class
    {
        public BaseSearchCommand()
        {
            OrderBy = null;
            Filter = null;
        }

        public string OrderBy { get; set; }
        public string Filter { get; set; }
        
    }
}
