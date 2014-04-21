using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.Inventory;

namespace PlataformaComercio.Web.vadministration.inventory
{
    public partial class inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["inventoryID"] != null)
            {
                btnAction.CommandName = "Edit";
            }
            else
            {
                btnAction.CommandName = "New";
            }
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                if (btnAction.CommandName == "New")
                {
                    Inventory inventory = new Inventory();
                    EntInventory entInventory = new EntInventory();
                    entInventory.InventoryID = txtID.Text;
                    entInventory.Description = txtDescription.Text;
                    entInventory.IsActive = chkIsActive.Checked;
                    inventory.Add(entInventory);
                    lblMessage.Text = "El inventario se agrego correctamente";
                }

            }
        }
    }
}