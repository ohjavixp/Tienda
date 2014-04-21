<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="buycart.aspx.cs" Inherits="PlataformaComercio.Web.BuyCart" %>
<%@ Register src="~/webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="center_content">
   	<h4>Carrito de compras</h4>
    <hr />


    <table class="footable table table-bordered" data-filter="#filter" data-page-size="20" data-page-previous-text="prev" data-page-next-text="next">
        <thead>
          <tr>
              <th data-sort-ignore="numeric">Cantidad</th>
              <th data-sort-ignore="alpha"data-hide="phone">Descripción</th>
              <th data-sort-ignore="true" data-hide="phone">Precio</th>
              <th data-sort-ignore="true" >Total</th>
          </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repBuyCart" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Textbox runat="server" id="txtQuantity" CssClass="form-control" text='<%# Eval("Quantity") %>' />
                        <asp:ImageButton ImageUrl="~/images/Edit16.png" runat="server" id="btnUpdateQuantity" AlternateText="Actualizar Cantidad"  CommandArgument='<%# Eval("Product.SKU") %>' OnCommand="btnUpdateQuantity_Command" />
                        <asp:ImageButton ImageUrl="~/images/RemoveRed16.png" runat="server" ID="imbDeleteProduct" CommandArgument='<%# Eval("Product.SKU") %>' OnCommand="lnbEliminar_Command" AlternateText="Eliminar Producto" />
                    </td>
                    <td><strong> <a href='<%# ResolveClientUrl("~/producto/detalleproducto/" + Eval("Sku"))%>'><%# Eval("Sku")%></a></strong> &nbsp-&nbsp <%# Eval("Product.ShortDescription") %></td>
                    <td><label class="price"><%# (decimal)Eval("Product.Price")%>&nbsp<%#Eval("Product.CurrencyIsoCode")%></label></td>
                    <td><label class="price"><%# (decimal)Eval("Total")%>&nbsp<%#Eval("Product.CurrencyIsoCode")%></label></td>
                </tr>               
            </ItemTemplate>
        </asp:Repeater>
        </tbody>
        <tfoot>
		    <tr>
		    	<td colspan="5" class="text-center">
		    		<ul class="pagination"></ul>
		    	</td>
		    </tr>
	    </tfoot>
    </table>
    <p class="text-right">SubTotal en pesos mexicanos <asp:Label ID="lblSubTotal" runat="server" Text="0.00" CssClass="text-info"></asp:Label></p>
    <br />
    <asp:Button ID="btnContinuar" runat="server" Text="Comprar" onclick="btnContinuar_Click" CssClass="btn btn-primary col-md-2" />
    
    <uc1:MessageControl ID="MessageControl1" runat="server" />
   </div><!-- end of center content -->        
        
    <link href="../css/FooTable-2/css/footable.core.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../css/FooTable-2/css/footable.standalone.css" rel="stylesheet" type="text/css" />--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script src="<%=Server.MapPath("~/css/FooTable-2/js/footable.js") %>" type="text/javascript"></script>
    <script src="../css/FooTable-2/js/footable.paginate.js" type="text/javascript"></script>
    <script src="../css/FooTable-2/js/footable.sort.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.footable').footable();
        });
    </script>

</asp:Content>
