<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.inventory._default" %>
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
    <asp:Button ID="btnNew" runat="server" Text="Nuevo" onclick="btnNew_Click" />
    <br />
    
    <asp:Repeater runat="server" ID="repInventories">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <%# Eval("InventoryID")%> &nbsp
                        <%# Eval("Description")%>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
    </asp:Repeater> 
</asp:Content>
