using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RenanRolo.ApiExceptions.Exceptions
{
    public class GravaLogException : SystemException
    {
        public GravaLogException()
        {
        }

        public GravaLogException(string message) : base(message)
        {
        }

        public GravaLogException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GravaLogException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
