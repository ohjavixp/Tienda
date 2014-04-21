<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master"
    AutoEventWireup="true" CodeBehind="addoreditproduct.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.products.addoreditproduct" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head"></asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="breadcrumb">
    <ul class="breadcrumb">  
        <li>  
          <a href="<%# ResolveClientUrl("~/administracion") %>">Inicio</a><span class="divider"></span>  
        </li>
        <li>
            <a href="<%# ResolveClientUrl("~/administracion/productos/agregar") %>">Lista Productos</a><span class="divider"></span> 
        </li>
        <li class="active">
            Agregar o Editar Producto
        </li>
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h4>Agregar o Editar Producto</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtProductID" CssClass="col-md-2 control-label">ID Producto</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtProductID" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtProductID"
                    CssClass="text-danger" ErrorMessage="El id del producto es requerido!!" />
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
            <asp:Label runat="server" AssociatedControlID="txtShortDescription" CssClass="col-md-2 control-label">Descripcion Corta</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtShortDescription" CssClass="form-control" TextMode="MultiLine" Rows="2"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtShortDescription"
                    CssClass="text-danger" ErrorMessage="La descripcion es requerida!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtLargeDescription" CssClass="col-md-2 control-label">Descripción Larga</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLargeDescription" CssClass="form-control" TextMode="MultiLine" Rows="5"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLargeDescription"
                    CssClass="text-danger" ErrorMessage="La descripcion larga es requerida!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtPrice" CssClass="col-md-2 control-label">Precio</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPrice"
                    CssClass="text-danger" ErrorMessage="El precio es reqerido!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlTrade" CssClass="col-md-2 control-label">Marca</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlTrade" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTrade"
                    CssClass="text-danger" ErrorMessage="La marca es requerida!!" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlCurrency" CssClass="col-md-2 control-label">Moneda</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCurrency"
                    CssClass="text-danger" ErrorMessage="La moneda es requerida!!"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="chkImage128" CssClass="col-md-2 control-label">Imagen 128</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox runat="server" ID="chkImage128"/>
                <asp:FileUpload runat="server" ID="fu128" Enabled="False"  style="display:inline;"/>
                <asp:Button  runat="server"  ID="btnAdd128" Enabled="False" Text="Add" OnCommand="btnAction_Command" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="chkImage256" CssClass="col-md-2 control-label">Imagen 256</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox runat="server" ID="chkImage256"/>
                <asp:FileUpload runat="server"  ID="fu256" Enabled="False" style="display:inline;"/>
                <asp:Button runat="server" ID="btnAdd256" Enabled="False" Text="Add" 
                    oncommand="btnAction_Command" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <div class="checkbox"><asp:CheckBox runat="server" ID="chkIsActive" Text="Activo"/></div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblWeight" AssociatedControlID="txtWeight" CssClass="col-md-2 control-label">Peso</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtWeight" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtMeasure" CssClass="col-md-2 control-label">Medidas (Alto x Largo x Ancho)</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtMeasure" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-8 col-md-10">
                <asp:Button ID="btnAction" runat="server" CssClass="btn btn-primary" OnCommand="btnAction_Command" />
                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Enabled="False" OnClick="btnDelete_Click" Text="Delete" />
            </div>
        </div>
    </div>
</asp:Content>