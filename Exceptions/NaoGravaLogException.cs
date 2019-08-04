using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RenanRolo.ApiExceptions.Exceptions
{
    public class NaoGravaLogException : SystemException
    {
        public NaoGravaLogException()
        {
        }

        public NaoGravaLogException(string message) : base(message)
        {
        }

        public NaoGravaLogException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NaoGravaLogException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
