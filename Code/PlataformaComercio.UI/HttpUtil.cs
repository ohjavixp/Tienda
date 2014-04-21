using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using PlataformaComercio.Entities.Inventory;
using System.Diagnostics;
using PlataformaComercio.FrameWork.Exceptions;

namespace PlataformaComercio.UI
{
    public class HttpUtil
    {
        
        
        public static string BuildUrl(EntInventoryCategory currentCategory, EntInventoryCategory[] inventoryCategories)
        {
            string url = BuildUrl(currentCategory, inventoryCategories, currentCategory.Name);
            url = ReplaceCharacters(url);
            url = "~/catalogo/" + url;
            //Debug.WriteLine(url);
            return ReplaceCharacters(url);
        }

        public static string BuildUrl(EntInventoryCategory currentCategory, EntInventoryCategory[] inventoryCategories, string url)
        {
            if (currentCategory.ParentID.Equals(0))
                return url;

            EntInventoryCategory parentCategory = inventoryCategories.Where(Categoria => Categoria.CategoryID.Equals(currentCategory.ParentID)).SingleOrDefault();

            if (parentCategory.CategoryID == parentCategory.ParentID)
            {
                throw new InternalException(String.Format("Error en BuildUrl La categoria {0} con ID {1} tiene como padre asi misma y provocaria un bucle infinito", parentCategory.Name, parentCategory.CategoryID));
            }

            string currentUrl = parentCategory.Name + "/" + url;
            return BuildUrl(parentCategory, inventoryCategories, currentUrl);
        }

        public static string ReplaceCharacters(string urlPart)
        {
            urlPart = urlPart.Trim().ToLower();
            urlPart = urlPart.Replace("    ", " ");
            urlPart = urlPart.Replace("   ", " ");
            urlPart = urlPart.Replace("  ", " ");
            urlPart = urlPart.Replace(" ", "-");
            urlPart = urlPart.Replace("á", "a");
            urlPart = urlPart.Replace("é", "e");
            urlPart = urlPart.Replace("í", "i");
            urlPart = urlPart.Replace("ó", "o");
            urlPart = urlPart.Replace("ú", "u");

            return urlPart;
        }

    }
}
