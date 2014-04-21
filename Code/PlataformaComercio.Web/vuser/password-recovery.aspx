<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="password-recovery.aspx.cs" Inherits="PlataformaComercio.Web.vuser.password_recovery" %>
<%@ Register src="../webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <h4>Recuperar contraseña</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUser" CssClass="col-md-2 control-label">Usuario o Correo Electronico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUser" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUser"
                    CssClass="text-danger" ErrorMessage="El id del producto es requerido!!" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-md-10">
                <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary" OnClick="Unnamed2_Click" Text="Enviar" />
            </div>
        </div>
            <uc1:MessageControl ID="MessageControl1" runat="server" />
    </div>
</asp:Content>
