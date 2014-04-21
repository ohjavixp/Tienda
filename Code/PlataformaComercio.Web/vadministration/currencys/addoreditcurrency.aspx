<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="addoreditcurrency.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.currencys.addoreditcurrency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%#ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider"></span>  
      </li>  
      <li>
          <a href="<%#ResolveClientUrl("~/administracion/tipodecambio") %>">Tipo de Cambio</a> <span class="divider"></span> 
      </li>
        <li class="active">
            Agregar Tipo de Cambio
        </li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-horizontal">
        <h4>Agregar o Editar Moneda</h4>
        <hr />

        <%--<dx:ASPxValidationSummary runat="server" CssClass="text-danger"/>--%>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtName" ReadOnly="true" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtExchangeRate" CssClass="col-md-2 control-label">Tipo de Cambio</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtExchangeRate" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnAction" runat="server" Text="" OnCommand="btnAction_Command" CssClass="btn btn-default"/>
                <a class="btn btn-primary" href="default.aspx">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>
