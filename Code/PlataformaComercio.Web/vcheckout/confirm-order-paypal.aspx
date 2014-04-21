<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="confirm-order-paypal.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.confirm_order" %>
<%@ Register src="../webcontrols/PayPalErrors.ascx" tagname="PayPalErrors" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnPay" runat="server" Text="Realizar Pago" 
        onclick="btnPay_Click" />
    <br />    
        
    <uc1:PayPalErrors ID="payPalErrors" runat="server" />
    
        
        
</asp:Content>
