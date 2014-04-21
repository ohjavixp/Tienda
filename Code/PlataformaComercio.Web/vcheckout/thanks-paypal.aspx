<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="thanks-paypal.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.thanks_paypal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Gracias, su transacción se realizo de manera correcta con el número de folio: 
    <asp:Label ID="lblFolio" runat="server" Text=""></asp:Label>, la transacción se confirmará en un máximo de 24 horas. 
    Dentro de este plazo verificaremos la existencia de los productos con tiempo de embarque de 1 a 2 días, de proceder este tiempo se realizará el cobro a su cuenta.
</asp:Content>
