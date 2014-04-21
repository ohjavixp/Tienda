using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.FrameWork.Exceptions;
using System.Diagnostics;

namespace PlataformaComercio.UI.Controls
{

    [ToolboxData("<PlataformaComercio:CatalogMenu runat=server></{PlataformaComercio}:CatalogMenu>")]
    public class CatalogMenu : WebControl
    {
        public CatalogMenu()
            : base(HtmlTextWriterTag.Div)
        { }


        protected override void RenderContents(HtmlTextWriter output)
        {
            //output.AddAttribute(HtmlTextWriterAttribute.Class, "jGM_box");
            //output.AddAttribute(HtmlTextWriterAttribute.Id, "jGlide_001");
            //output.RenderBeginTag(HtmlTextWriterTag.Div);
            //output.Write("Todas las categorias");
            


            Inventory inventory = new Inventory();
            EntInventoryCategory[] inventoryCategories = inventory.GetAllCategories();
            
            //Obtiene solo los que son visibles
            inventoryCategories = inventoryCategories.Where(Categoria => Categoria.Show == true).ToArray();

            int parentID = -1;
            string title = "Todas las categorias";
            string description = "";

            foreach (var item in inventoryCategories)
            {
                if (item.ParentID != parentID)
                {
                    if (parentID != -1)
                    {
                        output.RenderEndTag();
                    }

                    parentID = item.ParentID;

                    if (!parentID.Equals(0))
                    {                    
                        EntInventoryCategory parentCategory = inventoryCategories.Where(Categoria => Categoria.CategoryID.Equals(item.ParentID)).FirstOrDefault();
                        if (parentCategory == null)
                        {
                            continue;
                        }
                        title = parentCategory.Name;
                        description = parentCategory.ShortDescription;
                    }

                    //output.AddAttribute(HtmlTextWriterAttribute.Id, String.Format("tile_{0}", item.ParentID.ToString("000")));
                    //output.AddAttribute(HtmlTextWriterAttribute.Class, "jGlide_001_tiles");
                    //output.AddAttribute(HtmlTextWriterAttribute.Title, title);
                    //output.AddAttribute(HtmlTextWriterAttribute.Alt, description);
                    //output.RenderBeginTag(HtmlTextWriterTag.Ul);

                    CreateLiElement(item, output, inventoryCategories);
                }
                else
                {
                    CreateLiElement(item, output, inventoryCategories);
                }
            }

            //output.RenderEndTag();

            base.RenderContents(output);
        }

        private void CreateLiElement(EntInventoryCategory category, HtmlTextWriter output, EntInventoryCategory[] inventoryCategories)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Rel, String.Format("tile_{0}", category.CategoryID.ToString("000")));
            //output.RenderBeginTag(HtmlTextWriterTag.Li);

            int numberOfChilds = inventoryCategories.Where(Categoria => Categoria.ParentID.Equals(category.CategoryID)).Count();

            if (numberOfChilds == 0)
            {
                output.AddAttribute(HtmlTextWriterAttribute.Href, ResolveUrl(HttpUtil.BuildUrl(category, inventoryCategories)));
                output.AddAttribute(HtmlTextWriterAttribute.Class, "list-group-item");
                output.RenderBeginTag(HtmlTextWriterTag.A);
                    output.Write(category.Name);
                output.RenderEndTag();
            }
            else
                output.Write(category.Name);

            //output.RenderEndTag();
        }

        
    }
}
