using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.UI.Enums;

namespace PlataformaComercio.Web.webcontrols
{
    public partial class MessageControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            if (ShowMessage)
            {
                switch (MessageType)
                {
                    case MessageType.HighLight:
                        pnlHighLight.Visible = true;
                        break;
                    case MessageType.Error:
                        pnlError.Visible = true;
                        break;
                }
            }
        }

        public void Show(string message, MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.HighLight:
                    pnlHighLight.Visible = true;
                    break;
                case MessageType.Error:
                    pnlError.Visible = true;
                    break;
            }

            Message = message;
        }

        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public bool ShowMessage { get; set; }
    }
}