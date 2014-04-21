<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="selectpaymentmethod.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.selectpaymentmethod" %>
<%@ Register src="~/webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <h4>Seleccione su forma de pago</h4>
        <hr />
        
        <div class="form-group">
            <label class="FirstLabel text-info">Total de la orden : </label>
            <asp:Label ID="lblTotalPayment" runat="server" Text="" class="control-label"></asp:Label> 
        </div> 
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Formas de Pago</asp:Label>
            <div class="col-md-10">
                <asp:RadioButtonList ID="rblPaymentMethod" runat="server">
                    <asp:ListItem Value="1">Contra Entrega</asp:ListItem>
                    <asp:ListItem Value="2">PayPal</asp:ListItem>
                    <asp:ListItem Value="3">Transferencia Bancaria - Deposito en Cuenta</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnContinue" runat="server" Text="Continuar" 
                    CssClass="btn btn-primary" onclick="btnContinue_Click" />
            </div>
        </div>
        <uc1:messagecontrol id="MessageControl2" runat="server" />
        <uc1:MessageControl ID="MessageControl1" runat="server" />
    </div>
</asp:Content>
