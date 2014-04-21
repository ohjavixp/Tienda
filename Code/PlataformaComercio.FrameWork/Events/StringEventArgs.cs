using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.FrameWork.Events
{
    /// <summary>
    /// Pasa argumentos de evento del tipo string
    /// </summary>
    public class StringEventArgs: EventArgs
    {
        public string Data { get; set; }
        public  StringEventArgs(string data)
        {
            Data = data;
        }
    }
}
