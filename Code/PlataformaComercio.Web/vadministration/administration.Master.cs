using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlataformaComercio.Web.vadministration
{
    public partial class administration : System.Web.UI.MasterPage
    {
        private string backUrl;
        public string BackUrl 
        {
            get
            {
                if (string.IsNullOrEmpty(backUrl))
                {
                    backUrl = ResolveClientUrl("~/admin");
                }

                return backUrl;
            }
            set
            {
                backUrl = value;
            }
        }

        public string Title {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Page.Header.DataBind();
            }
        }
    }
}