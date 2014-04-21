using System;
using System.Collections.Specialized;

namespace PlataformaComercio.Web.Admin.DynamicData.FieldTemplates
{
    public partial class TextHtml_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetUpValidator(RequiredFieldValidator1);
            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(DynamicValidator1);
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            //dictionary[Column.Name] = ConvertEditedValue(WebHtmlEditor1.Text);
        }

        //public override Control DataControl
        //{
        //    get
        //    {
        //        return WebHtmlEditor1;
        //    }
        //}
    }
}