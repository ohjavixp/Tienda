using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.FrameWork.Events
{
    public class MessageEventArgs:EventArgs 
    {
        public string Header { get; set; }
        public string Message { get; set; }

        public MessageEventArgs(string header, string message)
        {
            Header = header;
            Message = message;
        }

        public MessageEventArgs(string message)
        {            
            Message = message;
        }
    }
}
