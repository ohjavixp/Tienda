<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addoreditbaseproduct.aspx.cs" MasterPageFile="~/vadministration/BootAdministration.Master"
    Inherits="PlataformaComercio.Web.vadministration.products.addoreditbaseproduct" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head"></asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="breadcrumb">
    <ul class="breadcrumb">  
        <li>  
          <a href="/vadministration/default.aspx">Inicio</a><span class="divider"></span>  
        </li>
        <li>
            <a href="/vadministration/default.aspx">Productos</a><span class="divider"></span> 
        </li>
        <li class="active">
            Agregar o Editar Producto
        </li>
    </ul>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="MainContent">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblPropertyCategoryID" AssociatedControlID="ddlPropertyCategoryID"
                runat="server" Text="Categoría" />
            <asp:DropDownList runat="server" ID="ddlPropertyCategoryID" AutoPostBack="True" OnSelectedIndexChanged="ddlPropertyCategoryID_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblPropertySubCategoryID" AssociatedControlID="ddlPropertySubCategoryID"
                runat="server" Text="Sub Categoría" />
            <asp:DropDownList runat="server" ID="ddlPropertySubCategoryID" OnSelectedIndexChanged="ddlPropertySubCategoryID_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblBaseProductID" AssociatedControlID="txtBaseProductID" runat="server"
                Text="ID Producto" />
            <asp:TextBox ID="txtBaseProductID" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" Text="Nombre producto" /><asp:TextBox
                ID="txtName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblIsActive" AssociatedControlID="chkIsActive" runat="server" Text="Activo"></asp:Label>
            <asp:CheckBox ID="chkIsActive" runat="server" /><br />
            <asp:Label ID="lblTrade" AssociatedControlID="ddlTrade" runat="server" Text="Marca" />
            <asp:DropDownList ID="ddlTrade" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblLastMod" AssociatedControlID="txtLastMod" runat="server" Text="Ultima Modificación"></asp:Label>
            <asp:TextBox ID="txtLastMod" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <asp:PlaceHolder runat="server" ID="phControles" />
            <br />
            <asp:Button ID="btnAction" runat="server" Text="" OnCommand="btnAction_Command" />
            &nbsp <a href="default.aspx">Regresar</a>
        </div>
    </form>
</asp:Content>