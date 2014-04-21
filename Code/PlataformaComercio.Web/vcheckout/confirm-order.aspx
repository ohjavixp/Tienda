<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="confirm-order.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.confirm_order1" %>
<%@ Register src="~/webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="form-horizontal">
        <h4>Confirmación de Órden</h4>
        <hr />
                      
           <div class="form-group">
                <label class="col-md-3 control-label">SubTotal de la orden : </label>
               <div class="col-md-9">
                   <asp:TextBox ID="txtSubTotal" runat="server" Enabled="false" class="form-control"></asp:TextBox>
               </div> 
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Gastos de envío : </label>
                <div class="col-md-9">
                    <asp:TextBox ID="txtShippingCost" runat="server" Enabled="false" class="form-control"/>
                </div>
            </div>
           <div class="form-group">
                <label class="col-md-3 control-label">Total de la orden : </label>                    
                <div class="col-md-9">
                    <asp:TextBox ID="txtTotalPayment" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                </div>
            </div>
        
            <div class="form-group">
                <label class="col-md-3 control-label">Dirección Envío : </label>                    
                <div class="col-md-9">
                    <asp:TextBox ID="txtAddress" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div> 
            </div>
        
            <div class="form-group">
                <label class="col-md-3 control-label">Forma De pago : </label>                    
                <div class="col-md-9">
                    <asp:TextBox ID="txtPaymentMethod" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        
            <div class="form-group">
                <label class="col-md-3 control-label">Forma De envío : </label>                    
                <div class="col-md-9">
                    <asp:TextBox ID="txtShippingMethod" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </div> 
            </div>
            <div class="form-group">
                <div class="col-md-offset-3">
                    <asp:Button ID="btnContinue" runat="server" Text="Confirmar Orden" CssClass="btn btn-primary" onclick="btnContinue_Click" />
                </div>
            </div>
        <uc1:messagecontrol id="MessageControl1" runat="server" />
    </div> 
</asp:Content>
