<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.products._default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%# ResolveClientUrl("~/administracion") %>">Inicio</a><span></span>  
      </li>
      <li class="active">
          Lista Productos
      </li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Lista Productos</h4>
    <hr />
    <%--<a href="<%= ResolveClientUrl("~/vadministration/products/addoreditproduct.aspx") %>" class="btn btn-primary">Crear</a> 
    <br />
    <br />
    <dx:ASPxGridView ID="dvGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0">
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataHyperLinkColumn Caption="Id Producto" FieldName="SKU" VisibleIndex="1">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="~/admin/products/{0}">
                </PropertiesHyperLinkEdit>
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Name" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Price" FieldName="Price" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn Caption="Activo" FieldName="IsActive" ReadOnly="True" VisibleIndex="4">
            </dx:GridViewDataCheckColumn>
        </Columns>
        <SettingsPager PageSize="20">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
    </dx:ASPxGridView> --%>
    
    <table class="footable table table-bordered" data-filter="#filter" data-page-size="20" data-page-previous-text="prev" data-page-next-text="next">
        <thead>
          <tr>
              <th data-type="alpha">Id Producto</th>
              <th data-type="alpha">Nombre</th>
              <th data-type="numeric" data-hide="phone">Price</th>
              <th data-sort-ignore="true" data-hide="phone">Activo</th>
          </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repProduct" runat="server">
            <ItemTemplate>
                <tr>
                    <td><a href="<%# ResolveClientUrl("~/administracion/productos/" + Eval("SKU"))%>"><%# Eval("SKU") %></a></td> 
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Price") %></td>
                    <td><%# Eval("IsActive") %></td>
                </tr>               
            </ItemTemplate>
        </asp:Repeater>
        </tbody>
        <tfoot>
		    <tr>
		    	<td colspan="4" class="text-center">
		    		<ul class="pagination"></ul>
		    	</td>
		    </tr>
	    </tfoot>
    </table>

    

    <link href="../../css/FooTable-2/css/footable.core.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../css/FooTable-2/css/footable.standalone.css" rel="stylesheet" type="text/css" />--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script src="../../css/FooTable-2/js/footable.js" type="text/javascript"></script>
    <script src="../../css/FooTable-2/js/footable.paginate.js" type="text/javascript"></script>
    <script src="../../css/FooTable-2/js/footable.sort.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('.footable').footable();
        });
    </script>
     
</asp:Content>
