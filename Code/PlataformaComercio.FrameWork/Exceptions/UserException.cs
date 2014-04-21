using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PlataformaComercio.FrameWork.Exceptions
{
    [global::System.Serializable]
    public class UserException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        bool haveValidationResults = false;
        ValidationResults validationResults = null;
        public UserException() { }
        public UserException(string message) : base(message) { }
        public UserException(string message, ValidationResults validationResults)
            : base(message) 
        {
            haveValidationResults = true;
            this.validationResults = validationResults;
        }
        public UserException(string message, Exception inner) : base(message, inner) { }
        protected UserException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
        public bool HaveValidationResults { get { return haveValidationResults; } }
    }
}
