<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="PlataformaComercio.Web.contact" %>
<%@ Register src="webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function initialize() {

            //if (GBrowserIsCompatible()) {
              //  var map = new GMap2(document.getElementById("map_canvas"));
               // map.setCenter(new GLatLng(19.391418, -99.09737), 16);
                

                //var point = new GLatLng(19.391418, -99.09737);
                //map.addOverlay(new GMarker(point));

                //var textNode = "<b>Espacio Mascota</b> <br/>";
                //textNode += "<b>Dirección: </b> Sur 147 # 2016 Col. Gabriel Ramos Millan, México D.F. 08730 <br/>";
                //textNode += "<b>Teléfono: </b> 01-55-5955-9877";

                //map.openInfoWindowHtml(map.getCenter(), textNode);
            //}            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div class="col-sm-offset-3 col-sm-6">
        <uc1:MessageControl ID="MessageControl1" runat="server" />
        <div class="form-horizontal well">
            <h4>Contactanos</h4>
            <hr />

                <div class="form-group">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Nombre"/>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*Ingrese Nombre" ControlToValidate="txtName"/>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"/>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="*Ingrese Correo Valido" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"/>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Telefono"/>
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Ingrese Telefono" ControlToValidate="txtPhone"/>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtMessage" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Mensaje"/>
                    <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ErrorMessage="Ingrese Mensaje" ControlToValidate="txtMessage"/> 
                </div>
                <div class="form-group">
                    
                    <%-- reCAPTCHA  --%>
                    <recaptcha:RecaptchaControl
                        ID="recaptcha"
                        runat="server"
                        PublicKey="6Lc3X-wSAAAAAGy8-aecupXFp54-W2GBN2sti7xB"
                        PrivateKey="6Lc3X-wSAAAAADelgmVeu1eS1EKDy56ykQ7Nd6Cl"/>

                </div>
                <div class="form-group">
                    <asp:Button ID="btnSend" runat="server" Text="Enviar"
                        CssClass="btn btn-primary" onclick="btnSend_Click"/>
                </div>
                <asp:Label ID="lblaviso" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
        </div>
    </div>
</div>
</asp:Content>
