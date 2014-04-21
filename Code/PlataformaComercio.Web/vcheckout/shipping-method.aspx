<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="shipping-method.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.shipping_method" %>
<%@ Register src="../webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Seleccione un método de envío</h3>
    <hr />
    <asp:BulletedList ID="blsShippingMethods" runat="server"></asp:BulletedList>
    <asp:Label ID="lblNoShipping" runat="server" Visible="false" Text="Lamentablemente no pudimos determinar de manera automatica el costo de envío, presione por favor el botón continuar para que un representante se ponga a la brevedad en contacto con usted y le proporcione el costo de envío"></asp:Label><br />
    <asp:Button ID="btnContinue" runat="server" Text="Continuar" CssClass="btn btn-primary" oncommand="btnContinue_Command" />

    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
</asp:Content>
