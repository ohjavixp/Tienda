<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true"
    CodeBehind="sendaddress.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.sendaddress" %>
<%@ Register src="~/webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<%@ Register assembly="PlataformaComercio.UI" namespace="PlataformaComercio.UI.Extenders" tagprefix="PlataformaComercio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="center_content">
        <asp:UpdateProgress ID="uprAjax" runat="server">
        <ProgressTemplate>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <div>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img id="Img1" src="~/Resources/Images/indicator.gif" runat="server" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Cargando, espere por favor...
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
         </ProgressTemplate>
         </asp:UpdateProgress>    
    <PlataformaComercio:UpdateProgressOverlayExtender ID="UpdateProgressOverlayExtender3" runat="server"
        CssClass="updateProgress" TargetControlID="uprAjax" OverlayType="Control" ControlToOverlayID="UpdatePanel1" />--%>
    
        <div class="form-horizontal" role="form">
            <h4>Dirección de envío</h4>
            <hr />

            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Pais</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                        <asp:ListItem Value="484">México</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Código Postal</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtZipCode" runat="server" ontextchanged="txtZipCode_TextChanged" AutoPostBack="true" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ErrorMessage="Codigo Postal Requerido!!" ControlToValidate="txtZipCode" 
                            ValidationGroup="valAddress"/>                                        
                        <%--<asp:RequiredFieldValidator ID="rfvZipCodeSearch" runat="server" ErrorMessage="*" ControlToValidate="txtZipCode" 
                            ValidationGroup="valAddressSearch"></asp:RequiredFieldValidator>--%>                                        
                        <%--<asp:ImageButton ImageUrl="~/images/SearchRun16.png" runat="server" ID="btnContinueZipCode" OnClick="btnContinueZipCode_Click" 
                            ValidationGroup="valAddressSearch"/>--%>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Colonia</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="ddlNeighborghood" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvNeighborghood" runat="server" ErrorMessage="Colonia Requerida!!" ControlToValidate="ddlNeighborghood"
                            ValidationGroup="valAddress"></asp:RequiredFieldValidator>
                    </div>                                        
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Delegación/Municipio</asp:Label>                    
                    <div class="col-md-10">
                        <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" Enabled="false"/>
                    <%--<asp:RequiredFieldValidator ID="rfvCountry" runat="server" ErrorMessage="Delegacion/Municipio Requerido!!"
                        ControlToValidate="lblCountry" ValidationGroup="valAddress"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Estado</asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtEstate" runat="server" CssClass="form-control" Enabled="false"/>
                    <%--<asp:RequiredFieldValidator ID="rfvEstate" runat="server" ErrorMessage="Estado Requerido!!" ControlToValidate="lblEstate"
                        ValidationGroup="valAddress"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="txtZipCode" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
                
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Calle</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtStreet" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rvfStreet" runat="server" ErrorMessage="*"
                            ControlToValidate="txtStreet" ValidationGroup="valAddress"/>
                    </div>                                        
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Número</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox ID="txtStreetNumber" runat="server" CssClass="form-control"/>
                            <asp:RequiredFieldValidator ID="rfvStreetNumber" runat="server" ErrorMessage="Numero Requerido!!" ControlToValidate="txtStreetNumber"
                                ValidationGroup="valAddress"/>
                        </div>
                </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">No. Interior</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtStreetInternalNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Entre las calles</asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtStreetBetween" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvStreetBetween" runat="server" ErrorMessage="Se requiere una referencia!!"
                        ControlToValidate="txtStreetBetween" ValidationGroup="valAddress"/>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Teléfono de contacto</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtTelephoneContact" runat="server" CssClass="form-control"/>
                        <asp:RequiredFieldValidator ID="rfvTelephone" runat="server" ErrorMessage="Telefono Requerido!!" 
                        ControlToValidate="txtTelephoneContact" ValidationGroup="valAddress"/>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="" CssClass="col-md-2 control-label">Comentarios de entrega</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Columns="1" TextWrapping="Wrap" AcceptsReturn="True" 
                        VerticalScrollBarVisibility="Visible" Rows="4" CssClass="form-control"/>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button ID="btnSaveAddress" runat="server" Text="Continuar" OnClick="btnSaveAddress_Click" ValidationGroup="valAddress" CssClass="btn btn-primary">
                    </asp:Button>
                    </div>
                </div>
            <uc1:messagecontrol id="MessageControl1" runat="server"/>
        </div>
</asp:Content>
