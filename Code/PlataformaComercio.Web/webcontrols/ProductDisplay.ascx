<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductDisplay.ascx.cs" Inherits="PlataformaComercio.Web.webcontrols.ProductDisplay" %>

<div class="col-sm-4 col-lg-4 col-md-4">
    <div class="thumbnail" style="height:inherit">
        <%--<a href="<%# ResolveClientUrl("~/producto/detalleproducto/" + Eval("Sku"))%>">
            <img id="Img2" src='<%# Eval("Image128Url")%>' runat="server"/>
        </a>--%>
        <img src="http://placehold.it/320x150" alt="">
        <div class="caption">
            <h4><a href="<%# ResolveClientUrl("~/producto/detalleproducto/" + Eval("Sku"))%>"><%# Eval("Name")%>&nbsp;</a></h4>
            <h5 class="text-right"><%# Eval("Price")%><%# Eval("CurrencyIsoCode")%></h5>
            <p><%# Eval("ShortDescription")%>&nbsp;</p>
        </div>
        <div style="padding-bottom:5px; padding-left:5px; padding-top:5px;">
            <asp:LinkButton ID="lbtnAgregarCarrito" runat="server" CommandArgument='<%# Eval("Sku") %>' OnCommand="imgAgregarCarrito_Command"
                    AlternateText="Agregar al carrito" CssClass="btn btn-primary"><span class="glyphicon glyphicon-shopping-cart"/></asp:LinkButton>
            <a href="<%# ResolveClientUrl("~/producto/detalleproducto/" + Eval("Sku"))%>" class="btn btn-default">details</a>
        </div>
    </div>
</div>