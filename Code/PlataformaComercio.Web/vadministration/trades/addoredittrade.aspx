<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master"
    AutoEventWireup="true" CodeBehind="addoredittrade.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.trades.addoredittrade" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%# ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider"></span>  
      </li>  
      <li class="active">
          Agregar o Editar Marca 
      </li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h4>Agregar o Editar Marca</h4>
        <hr />
        <dx:ASPxValidationSummary runat="server" CssClass="text-danger"/>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtName"
                    CssClass="text-danger" ErrorMessage="El nombre es requerido!!" />
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
            <asp:Label runat="server" AssociatedControlID="txtLargeDescription" CssClass="col-md-2 control-label">Descripcion Larga</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLargeDescription" CssClass="form-control" TextMode="MultiLine" Rows="5"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLargeDescription"
                    CssClass="text-danger" ErrorMessage="La desgripcion larga es requerida!!" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <div class="checkbox"><asp:CheckBox runat="server" ID="chkIsActive" Text="Activo"/></div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-md-10">
                <asp:Button ID="btnAction" runat="server" Text="" OnCommand="btnAction_Command" CssClass="btn btn-primary" />
                <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" Text="Eliminar" Visible="False" />
            </div>
        </div>
    </div>
</asp:Content>