using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.FrameWork.Exceptions
{
    [global::System.Serializable]
    public class InternalException : Exception
    {
        public InternalException() { }
        public InternalException(string message) : base(message) { }
        public InternalException(string message, Exception inner) : base(message, inner) { }
        protected InternalException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
