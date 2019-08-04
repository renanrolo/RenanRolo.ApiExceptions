using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenanRolo.ApiExceptions.TratarLog
{
    public class LogVO
    {
        public LogVO(Exception ex)
        {
            DataHora = DateTime.Now;
            Exception = ex;
        }

        public DateTime DataHora { get; private set; }

        public Exception Exception { get; private set; }
    }
}
