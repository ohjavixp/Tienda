<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="thanks-order.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.thanks_order" %>
<%@ Register src="../webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Gracias por su Órden</h3>
    <hr />
    <h4 class="text-center">Gracias por su compra</h4>
    <br />
    Se ha generado la órden número: <asp:Label ID="lblOrderNumber" Text="" runat="server" Font-Bold="true"  /> 
    &nbsp  por la cantidad de  <asp:Label ID="lblTotalOrder" Text="" runat="server" class="price"/> &nbsp un ejecutivo se pondrá en contacto con usted para confirmar su orden.
    <br />           
    <br />           
    <p>
        <label class="FirstLabel">SubTotal de la orden : </label>                    
        <asp:Label ID="lblSubTotal" runat="server" Text="" class="price"></asp:Label> 
    </p>
    <p >
        <label class="FirstLabel">Gastos de envío : </label>                    
        <asp:Label ID="lblShippingCost" runat="server" Text="Pendiente"/>
    </p>               

    <p >
        <label class="FirstLabel">Dirección Envío : </label>                    
        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label> 
    </p>

    <p >
        <label class="FirstLabel">Forma De pago : </label>                    
        <asp:Label ID="lblPaymentMethod" runat="server" Text="Pendiente"></asp:Label> 
    </p>

    <p >
        <label class="FirstLabel">Forma De envío : </label>                    
        <asp:Label ID="lblShippingMethod" runat="server" Text="Pendiente"></asp:Label> 
    </p>
    <br/>                              

        <br />
    <uc1:messagecontrol id="MessageControl1" runat="server" />
</asp:Content>
