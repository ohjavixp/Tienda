<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="view-or-edit-order.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.orders.view_or_edit_order" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%#ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider"></span>  
      </li>  
      <li class="active">
          Ver o Editar Orden 
      </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>Ver o Editar Orden</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtOrderId" class="col-md-2 control-label">Número Orden</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtOrderId" CssClass="form-control disabled" Enabled="false"/> 
            </div>
        </div>   
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtCreationDate" class="col-md-2 control-label">Fecha Creación</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCreationDate" CssClass="form-control disabled" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtLastUpdateDate" class="col-md-2 control-label">Ultima Actualización</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLastUpdateDate" CssClass="form-control disabled" Enabled="false"></asp:TextBox>    
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlStatus" class="col-md-2 control-label">Estatus</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control"/>    
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtClientName" class="col-md-2 control-label">Cliente</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtClientName" CssClass="form-control disabled" Enabled="false"/>    
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtSubTotal" class="col-md-2 control-label">SubTotal</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtSubTotal" CssClass="form-control disabled" Enabled="false"/>    
            </div>     
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtShippingCost" CssClass="col-md-2 control-label">Gastos de envío</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtShippingCost" CssClass="form-control"/>
            </div>      
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtTotalPayment" CssClass="col-md-2 control-label">Total de la orden</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtTotalPayment" CssClass="form-control disabled" Enabled="false"/>
            </div> 
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-2 control-label">Dirección Envío</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"/>
            </div> 
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPaymentMethod" CssClass="col-md-2 control-label">Forma De pago</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPaymentMethod" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtShippingMethod" CssClass="col-md-2 control-label">Forma De envío</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtShippingMethod" CssClass="form-control"/>
            </div> 
        </div>
    </div>

    <%--<dx:ASPxGridView ID="dvProducts" runat="server"></dx:ASPxGridView>--%>
    <br />
    <h4>Productos</h4>
    <hr />

    <table class="footable table table-bordered" data-filter="#filter" data-page-size="20" data-page-previous-text="prev" data-page-next-text="next">
        <thead>
          <tr>
              <th data-type="numeric">Order Id</th>
              <th data-sort-ignore="true" data-hide="phone">Inventory Id</th>
              <th data-sort-ignore="true" data-hide="phone">Sku</th>
              <th data-sort-ignore="true" data-hide="phone">ProductCategory Id</th>
              <th data-sort-ignore="true" data-hide="phone">Quantity</th>
              <th data-sort-ignore="true" data-hide="phone">UnitPrice</th>
          </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repProducts" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("OrderId") %></td>
                    <td><%# Eval("InventoryId") %></td>
                    <td><%# Eval("Sku") %></td>
                    <td><%# Eval("ProductCategoryId") %></td>
                    <td><asp:TextBox runat="server" ID="txtQuantity" Text='<%# Eval("Quantity") %>' CssClass="form-control" /></td>
                    <td><%# Eval("UnitPrice") %></td>
                </tr>               
            </ItemTemplate>
        </asp:Repeater>
        </tbody>
        <tfoot>
		    <tr>
		    	<td colspan="6" class="text-center">
		    		<ul class="pagination"></ul>
		    	</td>
		    </tr>
	    </tfoot>
    </table>

    <div class="form-inline">
        <div class="offset8">
            <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click"/>
            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-primary" Text="Cancelar" OnClick="btnCancel_Click"/>
        </div>
        <br />
    </div>

    <script type="text/javascript">
        function ActualizaPrecio() {
            var subtotal = document.getElementById('txtSubTotal').value;
            var precioEnvio = document.getElementById('txtShippingCost').value;
            var sum = 0 + parseInt(precioEnvio);
            document.getElementById('txtTotalPayment').value = sum;
        }
   </script>

    <%-- FooTable --%>
    <link href="../../css/FooTable-2/css/footable.core.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../css/FooTable-2/css/footable.standalone.css" rel="stylesheet" type="text/css" />--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script src="../../css/FooTable-2/js/footable.js" type="text/javascript"></script>
    <script src="../../css/FooTable-2/js/footable.paginate.js" type="text/javascript"></script>
    <script src="../../css/FooTable-2/js/footable.sort.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.footable').footable();
        });
    </script>

</asp:Content>
