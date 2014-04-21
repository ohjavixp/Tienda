using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.FrameWork.Configuracion;
using DevExpress.Web.ASPxGridView;

namespace PlataformaComercio.Web.vadministration.inventory
{
    public partial class inventory_category : System.Web.UI.Page
    {
        int categoryIdLoaded = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowData();
            }

            if (trvCategories.SelectedNode != null)
            {
                int categoryId = Int32.Parse(trvCategories.SelectedNode.Value);
                this.ShowProducts(categoryId,false);
                this.ShowCategories(categoryId);
            }
            
        }

        private void ShowData()
        {
            TreeNode parentNode = new TreeNode("Inventory", "0") { PopulateOnDemand = true };
            trvCategories.Nodes.Add(parentNode);
        }

        protected void trvCategories_TreeNodePopulate(object sender, TreeNodeEventArgs e)
        {
            Debug.WriteLine("Obteniendo hijos de " + e.Node.Text);

            Inventory inventory = new Inventory();
            EntInventoryCategory[] entInventoryCategory = null;

            switch (e.Node.Depth)
            {
                case 0:
                    entInventoryCategory = inventory.GetCategoriesByFatherID(0);
                    break;
                default:
                    entInventoryCategory = inventory.GetCategoriesByFatherID(Int32.Parse(e.Node.Value));
                    break;
            }

            if (entInventoryCategory != null)
            {
                foreach (var item in entInventoryCategory)
                {
                    AddChildNode(item.Name, item.CategoryID.ToString(), e.Node, true);
                }
            }
        }

        private void AddChildNode(string name, string value, TreeNode parentNode, bool populateOnDemand)
        {
            TreeNode node = new TreeNode(name, value);
            node.PopulateOnDemand = populateOnDemand;
            node.Expanded = false;
            if (parentNode == null)
                trvCategories.Nodes.Add(node);
            else
                parentNode.ChildNodes.Add(node);
        }

        protected void trvCategories_SelectedNodeChanged(object sender, EventArgs e)
        {
            phCategoryDetail.Visible = true;
            lblCategoryName.Text = trvCategories.SelectedNode.Text;
            btnNew.Enabled = true;
            btnNew.CssClass = "btn btn-small btn-primary";

            int categoryID = Int32.Parse(trvCategories.SelectedNode.Value);

            ShowCategories(categoryID);
            ShowProducts(categoryID,false);
        }

        private void ShowCategories(int categoryID)
        {
            Inventory inventory = new Inventory();
            EntInventoryCategory[] entInventoryCategories = null;
            entInventoryCategories = inventory.GetCategoriesByFatherID(categoryID);
            repGridCategories.DataSource = entInventoryCategories;
            repGridCategories.DataBind();
            //dvGridCategories.DataSource = entInventoryCategories;
            //dvGridCategories.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                EntInventoryCategory entInventoryCategory = new EntInventoryCategory();
                entInventoryCategory.InventoryID = InventoryConfiguration.DefaultInventory;
                entInventoryCategory.Name = txtName.Text;
                entInventoryCategory.ShortDescription = txtShortDescription.Text;
                entInventoryCategory.Description = txtLargeDescription.Text;
                entInventoryCategory.IsActive = chkIsActive.Checked;
                entInventoryCategory.Order = short.Parse(txtOrder.Text);
                entInventoryCategory.Show = chkShow.Checked;

                Inventory inventory = new Inventory();
                if (e.CommandName == "New")
                {
                    entInventoryCategory.ParentID =trvCategories.SelectedNode == null?0: Int32.Parse(trvCategories.SelectedNode.Value);

                    int categoryID = inventory.AddCategory(entInventoryCategory);

                    if (trvCategories.SelectedNode != null && trvCategories.SelectedNode.ChildNodes.Count == 0)
                    {
                        trvCategories.SelectedNode.Expanded = true;
                    }
                    else
                    {
                        AddChildNode(entInventoryCategory.Name, categoryID.ToString(), trvCategories.SelectedNode, true);
                    }
                }
                else
                {
                    entInventoryCategory.CategoryID = Int32.Parse(e.CommandArgument.ToString());
                    inventory.UpdateCategory(entInventoryCategory);
                    TreeNode node = trvCategories.FindNode(String.Format("{0}/{1}", trvCategories.SelectedNode.ValuePath, entInventoryCategory.CategoryID));
                    if (node != null)
                    {
                        node.Text = txtName.Text;
                    }
                }

                txtName.Text = string.Empty;
                txtShortDescription.Text = string.Empty;
                txtLargeDescription.Text = string.Empty;
                chkIsActive.Checked = true;
                txtOrder.Text = "0";
                plhAction.Visible = false;

                if (trvCategories.SelectedNode != null)
                    ShowCategories(Int32.Parse(trvCategories.SelectedNode.Value));
            }
        }

        private void ShowProducts(int p, bool forceLoad)
        {
            if (!forceLoad &&  categoryIdLoaded.Equals(p))
            {
                return;
            }
            categoryIdLoaded = p;
            Inventory inventory = new Inventory();
            var products = inventory.GetProductsByCategory(p);
            repCategoryProduct.DataSource = products;
            repCategoryProduct.DataBind();
            //dvGridCategoryProducts.DataSource = products;
            //dvGridCategoryProducts.DataBind();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            btnAction.CommandName = "New";
            btnAction.Text = "Crear";
            plhAction.Visible = true;
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            EntInventoryCategoryProduct categoryProduct = new EntInventoryCategoryProduct() { InventoryID = InventoryConfiguration.DefaultInventory, CategoryID = Int32.Parse(trvCategories.SelectedNode.Value), ProductID = txtSku.Text, IsPrimary = false, IsActive = true };
            inventory.AddProductToCategory(categoryProduct);

            int categoryID = Int32.Parse(trvCategories.SelectedNode.Value);
            ShowProducts(categoryID,true);
        }

        protected void dvGridCategoryProducts_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

            Inventory inventory = new Inventory();
            inventory.DeleteProductFromCategory(InventoryConfiguration.DefaultInventory, Int32.Parse(trvCategories.SelectedNode.Value),e.Keys[0].ToString());
            e.Cancel = true;
            ShowProducts(Int32.Parse(trvCategories.SelectedNode.Value), true);
        }

        protected void dvGridCategories_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            
            ASPxGridView grid = sender as ASPxGridView;
            var row = (EntInventoryCategory)grid.GetRow(e.VisibleIndex);
            Inventory inventory = new Inventory();
            if (e.ButtonID.Equals("btnUpdateCategory"))
            {
                EntInventoryCategory entInventoryCategory = inventory.GetCategory(InventoryConfiguration.DefaultInventory,row.CategoryID);

                if (entInventoryCategory == null)
                {
                    return;
                }

                txtName.Text = entInventoryCategory.Name;
                txtShortDescription.Text = entInventoryCategory.ShortDescription;
                txtLargeDescription.Text = entInventoryCategory.Description;
                chkIsActive.Checked = entInventoryCategory.IsActive;
                txtOrder.Text = entInventoryCategory.Order.ToString();
                chkShow.Checked = entInventoryCategory.Show;

                btnAction.CommandName = "Edit";
                btnAction.Text = "Editar";
                btnAction.CommandArgument = row.CategoryID.ToString();
                plhAction.Visible = true;
                return;
            }

            if (e.ButtonID.Equals("btnUpdateCategory"))
            {
                int categoryID = Convert.ToInt32(row.CategoryID);
                inventory.DeleteCategory(categoryID);

                TreeNode node = trvCategories.FindNode(String.Format("{0}/{1}", trvCategories.SelectedNode.ValuePath, categoryID));
                node.Parent.ChildNodes.Remove(node);
                grid.DeleteRow(e.VisibleIndex);
            }
        }

    }
}