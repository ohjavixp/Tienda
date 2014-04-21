<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="VerDetalleProducto.aspx.cs" Inherits="PlataformaComercio.Web.VProducto.VerDetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .thumbnail img {
          width: auto;
        }
    </style>

    <div class="thumbnail">
        <asp:Image ID="imgProductoLarga" runat="server" CssClass="img-responsive ImgDetail"/>
      <%--<img class="img-responsive" src="http://placehold.it/800x300" alt=""/>--%>
      <div class="caption-full">
        <h4 class="pull-right text-primary"><asp:Label ID="lblPrice" Text="" runat="server"/>&nbsp<asp:Label ID="lblIsoCode" Text="" runat="server"/></h4>
        <h4 class="text-info"><asp:Label ID="lblName" runat="server" Text="Label"/></h4>
        <p><asp:Label ID="lblDescripcionLarga" runat="server" Text="Label"/></p>
      </div>
      <div class="text-center" style="padding-bottom:10px">
          <asp:LinkButton ID="lnkAddToCart" Text="Comprar" runat="server" CssClass="btn btn-primary" OnCommand="imgAgregarCarrito_Command">
              <span class="glyphicon glyphicon-shopping-cart"></span>Comprar
          </asp:LinkButton>
      </div>
    </div>


    
</asp:Content>
