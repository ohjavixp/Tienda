<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="iniciar-sesion.aspx.cs" Inherits="PlataformaComercio.Web.vuser.iniciar_sesion" %>
<%@ Register src="../webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <uc1:MessageControl ID="MessageControlFromPage" runat="server" />
    <br />
    <br />
    
    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
        <div class="form-horizontal well">
            <h4>Iniciar Sesión.</h4>
            <hr />
              <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class=" alert alert-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtUser" CssClass="col-md-4 control-label">Nombre de Usuario</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtUser" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUser"
                        CssClass="text-danger" ErrorMessage="El Nombre de Usuario es Requerido." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-4 control-label">Contraseña</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="La Contraseña es Requerida." />
                </div>
            </div>
            <%--<div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <div class="checkbox">
                        <asp:CheckBox runat="server" ID="RememberMe" />
                        <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                    </div>
                </div>
            </div>--%>
            <div class="form-group">
                <div class="col-md-offset-4 col-md-10">
                    <asp:Button runat="server" OnClick="btnAutenticate_Click" Text="Iniciar Sesion" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
        <p class="text-right">
            <a id="A1" href="~/usuario/recuperar-password" runat="server">¿Olvidaste Tu Contraseña?</a>
            <asp:HyperLink runat="server" ID="hplCreateUser" NavigateUrl="~/usuario/crear" Text="Crear Usuario"></asp:HyperLink>
        </p>
        </div>
    </div>
    
    <%--<div class="center_content">
   	<div class="center_title_bar"><h1>Iniciar Sesión</h1></div>
    
    	<div class="prod_box_big">
        	<div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">            
                 
              	
                           
                    <asp:Label ID="Label1" Text="Nombre de usuario :" CssClass="FirstLabel" runat="server" AssociatedControlID="txtUser" />  
        			<asp:TextBox ID="txtUser" runat="server"></asp:TextBox><br />
                
                
                   <asp:Label ID="Label2" Text="Contraseña :" CssClass="FirstLabel" runat="server" AssociatedControlID="txtPassword" />            
                   <asp:TextBox  ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />                
                    <br />      
                    <br />      
                    <asp:Button ID="btnAutenticate" runat="server" Text="Iniciar Sesión" CssClass="ui-state-default"
                        onclick="btnAutenticate_Click"></asp:Button> <a id="A1" href="~/usuario/recuperar-password" runat="server">¿Olvidaste tu contraseña?</a>
                    <br />
                    <br />
                    <uc1:MessageControl ID="MessageControl1" runat="server" />
                    
                
                
                                     
            </div>
            <div class="bottom_prod_box_big"></div>                                
        </div>
       
    
   
   </div><!-- end of center content -->
   
   <div class="center_content">
   	<div class="center_title_bar">¿Aún no tienes usuario?</div>
    
    	<div class="prod_box_big">
        	<div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">            
                 
              	<div class="contact_form">
                           
                    <p> 
                    Crea uno y comienza a disfrutar de todos nuestro beneficios                    
                    <asp:HyperLink CssClass="ui-state-default ui-corner-all" runat="server" ID="hplCreateUser" NavigateUrl="~/usuario/crear" Text="Crear"></asp:HyperLink>                
                </p>
                    
                </div> 
                
                                     
            </div>
            <div class="bottom_prod_box_big"></div>                                
        </div>
       
    
   
   </div><!-- end of center content -->    --%>
    
</asp:Content>
