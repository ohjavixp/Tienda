<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true"
    CodeBehind="create.aspx.cs" Inherits="PlataformaComercio.Web.vuser.create" %>


<%@ Register src="~/webcontrols/MessageControl.ascx" tagname="MessageControl" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .dropdown {
            width: auto;
            display: inline;
        }
    </style>

    <div class="form-horizontal">
        <h4>Recuperar contraseña</h4>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
        </asp:PlaceHolder>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtUserName" CssClass="col-md-2 control-label">Nombre de Usuario</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                    CssClass="text-danger" ErrorMessage="El nombre del usuario es requerido" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPassword" CssClass="col-md-2 control-label">Contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                    CssClass="text-danger" ErrorMessage="El Password es requerido" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPasswordConfirm" CssClass="col-md-2 control-label">Confirmación Contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPasswordConfirm" CssClass="form-control" TextMode="Password"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPasswordConfirm"
                    CssClass="text-danger" ErrorMessage="La confirmacion de la contraseña es requerida" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="El Nombre es requerido!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Apellidos</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                    CssClass="text-danger" ErrorMessage="Los Apellidos son requeridos!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Correo Electronico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                    CssClass="text-danger" ErrorMessage="El correo es requerido!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtConfirmEmail" CssClass="col-md-2 control-label">Confirmacion de Correo Electronico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtConfirmEmail" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmEmail"
                    CssClass="text-danger" ErrorMessage="La confirmacion de correo es requerida!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Fecha de Nacimiento</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDay" runat="server" CssClass="form-control dropdown"/>
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control dropdown"/>
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control dropdown"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Sexo</asp:Label>
            <div class="col-md-10">
                <asp:RadioButton ID="rdbSexMale" runat="server" GroupName="SexGroup" Text="Hombre"/>
                <asp:RadioButton ID="rdbFemale" runat="server" GroupName="SexGroup" Text="Mujer" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Numero de Telefono</asp:Label>
            <div class="col-md-10">
                <div class="form-inline">
                    <div class="form-group"  style="padding-left:15px;">
                        <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control"  placeholder="Telefono"/>
                    </div>
                    <div class="form-group" style="padding-left:30px;">
                        <asp:TextBox runat="server" ID="txtPhoneNumberExt" CssClass="form-control" placeholder="Ext."/>
                    </div>
                </div>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhoneNumber"
                    CssClass="text-danger" ErrorMessage="El Numero de telefono es requerido" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtMobileNumber" CssClass="col-md-2 control-label">Telefono Celular</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" id="txtMobileNumber" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMobileNumber"
                    CssClass="text-danger" ErrorMessage="Se requiere el numero de celular" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:CheckBox ID="chkSendInfo" runat="server" Text="Enviarme Promociones" Checked="true" CssClass="checkbox"/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:CheckBox ID="chkShareInfo" runat="server" Text="Compartir datos con marcas" CssClass="checkbox"/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="btnCreate" CssClass="btn btn-primary" runat="server" Text="Crear" OnClick="btnCreate_Click"/>
            </div>
        </div>
            <uc1:MessageControl ID="MessageControl2" runat="server" />
    </div>

<%--<div class="center_content">
   	<div class="center_title_bar"><h1>Crear Usuario</h1></div>
    
    	<div class="prod_box_big">
        	<div class="top_prod_box_big"></div>
            <div class="center_prod_box_big">            
                
                <p>
                <label class="FirstLabel">
                    Nombre de Usuario</label>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserName" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
                </p>
            <p>
                <label class="FirstLabel">
                    Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
            </p>
            <p>
                <label class="FirstLabel">
                    Confirmación Contraseña</label>
                <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPasswordConfirm" runat="server" ErrorMessage="*" ControlToValidate="txtPasswordConfirm" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
            </p>
            <p>
            
                <label class="FirstLabel">
                    Nombre</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
            </p>
            <p>
                <label class="FirstLabel">
                    Apellidos</label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="*" ControlToValidate="txtLastName" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
            </p>
            <p>
                <label class="FirstLabel">
                    Correo Electronico</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
            </p>
            <p>
                <label class="FirstLabel">
                    Confirmación Correo Electronico</label>
                <asp:TextBox ID="txtConfirmEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ErrorMessage="*" ControlToValidate="txtConfirmEmail" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
            </p>
            <p>
                <label class="FirstLabel">
                    Fecha de Nacimiento (DD/MM/AAAAA)</label>
                <asp:DropDownList ID="ddlDay" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                <label class="FirstLabel">
                    Sexo</label>
                <asp:RadioButton ID="rdbSexMale" runat="server" GroupName="SexGroup" Text="Hombre">
                </asp:RadioButton>
                <asp:RadioButton ID="rdbFemale" runat="server" GroupName="SexGroup" Text="Mujer">
                </asp:RadioButton></p>
            <p>
                <label class="FirstLabel">
                    Número de telefono</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server"/>
                <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="*" ControlToValidate="txtPhoneNumber" ValidationGroup="calCreateUser" SetFocusOnError="true"/>
                
                <label>
                    Extensión</label>
                <asp:TextBox ID="txtPhoneNumberExt" runat="server" Width="67px"></asp:TextBox>
            </p>
            <p>
                <label class="FirstLabel">
                    Telefono Celular</label>
                <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox></p>
            <p>
                <label class="FirstLabel">
                    Enviarme promociones</label>
                <asp:CheckBox ID="chkSendInfo" runat="server" Checked="true" Text=""></asp:CheckBox></p>
            <p>
                <label class="FirstLabel">
                    Compartir datos con marcas</label>
                <asp:CheckBox ID="chkShareInfo" runat="server" Text=""></asp:CheckBox></p>
            <asp:Button ID="btnCreate" CssClass="ui-state-default ui-corner-all" runat="server" Text="Crear" OnClick="btnCreate_Click">
            </asp:Button>
            
            
            
            <uc1:MessageControl ID="MessageControl1" runat="server" />
            
            
                                     
            </div>
            <div class="bottom_prod_box_big"></div>                                
        </div>
       
    
   
   </div><!-- end of center content -->--%>
</asp:Content>
