using PlataformaComercio.Business.OrderManagement;
using PlataformaComercio.Business.Enums;
using PlataformaComercio.UI.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlataformaComercio.Web.vadministration.orders
{
    public partial class view_or_edit_order : System.Web.UI.Page, IDetalleOrden
    {
        #region IGenericDisplay Members

        public RouteValueDictionary RoutedValues
        {
            get;
            set;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(OrderId))
                    Response.Redirect("default.aspx");

                if (!string.IsNullOrEmpty(OrderId))
                    this.ShowOrder(Int32.Parse(OrderId));

                ddlStatus.Items.Clear();
                foreach (EOrderStatus item in Enum.GetValues(typeof(EOrderStatus)))
                {
                    ddlStatus.Items.Add(new ListItem(item.ToString(), Convert.ToInt32(item).ToString()));
                }
            }
        }

        private void ShowOrder(int orderId)
        {
            OrderCatalog orderCatalog = new OrderCatalog();
            PlataformaComercio.Business.OrderManagement.Order order = orderCatalog.GetById(orderId);

            this.txtOrderId.Text = order.OrderId.ToString();
            this.txtCreationDate.Text = order.CreationDate.ToShortDateString();
            this.txtLastUpdateDate.Text = order.LastUpdate.ToShortDateString();
            this.txtClientName.Text = order.ClientName;
            this.ddlStatus.Text = order.Status.ToString();
            this.txtSubTotal.Text = order.SubTotal.ToString();
            this.txtTotalPayment.Text = order.Total.ToString();

            this.repProducts.DataSource = order.Products;
            this.repProducts.DataBind();

            
            txtShippingCost.Text = order.Shipping.ShippingMethods.ShippingCost.ToString();
            txtAddress.Text = string.Format("{0} número: {1} {2} entre las calles: {3} código postal: {4}", order.Shipping.ShippingAddress.Address.Street, order.Shipping.ShippingAddress.Address.StreetNumber,
                string.IsNullOrEmpty(order.Shipping.ShippingAddress.Address.StreetInternalNumber) ? string.Empty : " número interno: " + order.Shipping.ShippingAddress.Address.StreetInternalNumber,
                order.Shipping.ShippingAddress.Address.StreetBetween, order.Shipping.ShippingAddress.Address.ZipCode);
            //lblShippingMethod.Text = order.Shipping.ShippingMethods.ShippingMethod.ShippingType.Name;
            txtPaymentMethod.Text = order.PaymentMethod.Payment[0].PaymentType.Name;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        #region IDetalleOrden Members

        public string OrderId
        {
            get;
            set;
        }

        #endregion
    }
}