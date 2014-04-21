using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace PlataformaComercio.UI.Extenders
{
    public abstract class ExtenderBase : ExtenderControl
    {
        internal const string Control_Not_Found = "Unable to find control id '{0}' referenced by the '{1}' property of '{2}'";
        internal const string Target_Is_Null = "The target control is not defined.";

        /// <summary>
        /// Locate control by walking up the control tree
        /// ref: Ajax Control Toolkit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal Control FindControlHelper(string id)
        {
            Control c = base.FindControl(id);
            Control nc = NamingContainer;

            while ((null == c) && (null != nc))
            {
                c = nc.FindControl(id);
                nc = nc.NamingContainer;
            }
            return c;
        }
    }
}
