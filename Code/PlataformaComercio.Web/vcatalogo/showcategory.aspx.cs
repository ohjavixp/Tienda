using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.UI.Routing;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.FrameWork.Configuracion;
using System.Text;

namespace PlataformaComercio.Web.VCatalogo
{
    public partial class showcategory : System.Web.UI.Page, IGenericDisplay
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoutedValues == null)
                Response.Redirect("~/default.aspx");
            
            ShowMenu();

            if (!Page.IsPostBack)
                MostrarProductos();           
            
        }

        private void ShowMenu()
        {
            List<string> values = GetCategories();
            /*
            
            jQuery.jGlideMenu.loadTile('tile_047', jQuery.jGlideMenu.URLParams);
            jQuery.jGlideMenu.loadTile('tile_048', jQuery.jGlideMenu.URLParams);
            jQuery.jGlideMenu.loadTile('tile_054', jQuery.jGlideMenu.URLParams);
            jQuery.jGlideMenu.defaultScrollSpeed = 750;*/

            
            if (!Page.ClientScript.IsClientScriptBlockRegistered("MenuCategoryFunction"))
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("function ShowCategoryMenu(){");                
                
                Inventory inventory = new Inventory();
                int[] categoriesID = inventory.GetCategoriesIDByName(values.ToArray());

                //Se excluye la categoria actual
                for (int i = 0; i < categoriesID.Length -1; i++)
                {
                    sbScript.AppendFormat("jQuery.jGlideMenu.loadTile('tile_{0}', jQuery.jGlideMenu.URLParams);", categoriesID[i].ToString("000"));    
                }

                sbScript.Append("jQuery.jGlideMenu.defaultScrollSpeed = 750;");
                sbScript.Append("}");

                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "MenuCategoryFunction", sbScript.ToString(), true);

            }
        }

        private void MostrarProductos()
        {            
            EntProduct[] productos = ObtenerProductos();

            var result  = productos.Where(Producto => Producto.IsActive == true).ToArray();

            if (result != null)
            {

                repProducts.DataSource = result;
                repProducts.DataBind();
            }
        }

        private EntProduct[] ObtenerProductos()
        {
            if (RoutedValues == null)
                Response.Redirect("/");
            
            Inventory ctrlCatalogo = new Inventory();

            List<string> values = GetCategories();

            StringBuilder sbTitle = new StringBuilder();
            
            foreach (var item in values)
            {
                sbTitle.Append(" - " + item);    
            }

            Page.Title = "Productos de la categoria " + sbTitle.ToString();            
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription("Mostrando los productos de la categoria " + sbTitle.ToString());

            return ctrlCatalogo.GetProductsByCategory(values.ToArray());                
            
        }

        private List<string> GetCategories()
        {
            List<string> values = new List<string>();
            foreach (var item in RoutedValues)
            {
                values.Add(ReplaceValues(item.Value.ToString()));
            }
            return values;
        }

        private string ReplaceValues(string value)
        {
            value = value.Replace("-", " ");
            return value;
        }


        



        #region INivelDisplay Members

        public System.Web.Routing.RouteValueDictionary RoutedValues
        {
            get;
            set;
        }

        #endregion
    }
}
