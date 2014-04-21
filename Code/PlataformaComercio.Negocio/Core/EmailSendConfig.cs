using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Business.Core
{
    public class EmailSendConfig
    {
        public string From { get; set; }
        public string TO { get; set; }
        public bool IsBodyHtml { get; set; }
        public EmailSendTemplate Template { get; set; }
        public string Subjet { get; set; }
    }
}
