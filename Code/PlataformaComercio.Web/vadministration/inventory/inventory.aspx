<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="inventory.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.inventory.inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%#ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider"></span>  
      </li>  
      <li class="active">
          Inventario
      </li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    ID:     <asp:TextBox ID="txtID" runat="server"></asp:TextBox> <br/>
    Descripción : <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox> <br/>
    Acitivo :     <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" /><br/>
    <asp:Button ID="btnAction" runat="server" Text=""  oncommand="btnAction_Command" />
    
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    
</asp:Content>
