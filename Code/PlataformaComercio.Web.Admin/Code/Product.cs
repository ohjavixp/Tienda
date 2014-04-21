using System.ComponentModel.DataAnnotations;

namespace PlataformaComercio.Web.Admin
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        partial void OnLargeDescriptionChanged()
        {
            //WebHtmlEditor htmlEdito = new WebHtmlEditor();
            //htmlEdito.Text = _LargeDescription;
            //this._LargeDescriptionRaw = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(htmlEdito.TextPlain, false);
        }
    }

    public class ProductMetadata
    {
        [UIHint("TextHtml")]
        public object LargeDescription { get; set; }

        [System.ComponentModel.DataAnnotations.Editable(false)]
        public object LargeDescriptionRaw { get; set; }

        [System.ComponentModel.DataAnnotations.Editable(false)]
        public object LastMod { get; set; }
    }
}