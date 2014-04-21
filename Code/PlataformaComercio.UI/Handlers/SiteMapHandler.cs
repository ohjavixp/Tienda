using System;
using System.Web;
using PlataformaComercio.Entities.Inventory;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using PlataformaComercio.Entities.UI;
using PlataformaComercio.Business;
using System.Linq;

namespace PlataformaComercio.UI.Handlers
{
    public class SiteMapHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            

            if (context.Request.FilePath.Equals("/sitemap.xml"))
            {

                StringBuilder sbXml = new StringBuilder();
                sbXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?> ");
                sbXml.Append("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd\">");


                PlataformaComercio.Business.Catalogs.SiteMap siteMap = new PlataformaComercio.Business.Catalogs.SiteMap();


                var info = siteMap.GetAll();

                List<EntSiteMapUI> siteMapInfo = new List<EntSiteMapUI>(info);


                siteMapInfo = GenerateCategoryUrls(siteMapInfo);

                foreach (var item in siteMapInfo)
                {
                    item.Url = HttpUtility.UrlPathEncode("http://" + context.Request.Url.Authority + item.Url);
                    sbXml.AppendFormat("<url><loc>{0}</loc> <changefreq>monthly</changefreq> </url>", item.Url);
                    Debug.WriteLine(item.Url);
                }

                sbXml.Append("</urlset>");

                context.Response.Write(sbXml.ToString());
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/xml";
            }
        }

        #endregion

        #region Private Methods
        private List<EntSiteMapUI> GenerateCategoryUrls(List<EntSiteMapUI> siteMapInfo)
        {

            Inventory inventory = new Inventory();
            EntInventoryCategory[] inventoryCategories = inventory.GetAllCategories();

            //Obtiene solo los que son visibles
            inventoryCategories = inventoryCategories.Where(Categoria => Categoria.Show == true).ToArray();

            int parentID = -1;

            foreach (var item in inventoryCategories)
            {
                if (item.ParentID != parentID)
                {
                    if (parentID != -1)
                    {

                    }

                    parentID = item.ParentID;

                    if (!parentID.Equals(0))
                    {
                        EntInventoryCategory parentCategory = inventoryCategories.Where(Categoria => Categoria.CategoryID.Equals(item.ParentID)).Single();
                    }

                    string url = BuildUrl(item, inventoryCategories);
                    if (!string.IsNullOrEmpty(url))
                        siteMapInfo.Add(new EntSiteMapUI() { Url = url, LasMod = DateTime.Now });

                }
                else
                {
                    string url = BuildUrl(item, inventoryCategories);
                    if (!string.IsNullOrEmpty(url))
                        siteMapInfo.Add(new EntSiteMapUI() { Url = url, LasMod = DateTime.Now });
                }
            }



            return siteMapInfo;
        }

        public string BuildUrl(EntInventoryCategory category, EntInventoryCategory[] inventoryCategories)
        {


            int numberOfChilds = inventoryCategories.Where(Categoria => Categoria.ParentID.Equals(category.CategoryID)).Count();

            if (numberOfChilds == 0)
            {
                string url = HttpUtil.BuildUrl(category, inventoryCategories);
                return url;
            }
            else
            {
                return string.Empty;
            }



        }
        #endregion
    }
}
