<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" 
    Inherits="PlataformaComercio.Web.vadministration.orders._default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Data.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%#ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider"></span>  
      </li>  
      <li class="active">
          Ordenes
      </li>
    </ul>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Ordenes</h4>
    <hr />
    <%--<dx:ASPxGridView ID="dvGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <dx:GridViewDataHyperLinkColumn Caption="ID" FieldName="OrderId" VisibleIndex="0">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="~/admin/orders/{0}">
                </PropertiesHyperLinkEdit>
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewDataTextColumn Caption="Cliente" FieldName="ClientName" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="SubTotal" FieldName="SubTotal" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Estatus" FieldName="Status" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Creada" FieldName="CreationDate" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsPager PageSize="25">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
    </dx:ASPxGridView>--%>

    <table class="footable table table-bordered" data-filter="#filter" data-page-size="20" data-page-previous-text="prev" data-page-next-text="next">
        <thead>
          <tr>
              <th data-type="numeric">Id</th>
              <th data-type="alpha">Cliente</th>
              <th data-sort-ignore="true" data-hide="phone">SubTotal</th>
              <th data-sort-ignore="true" data-hide="phone">Estatus</th>
              <th data-sort-ignore="true" data-hide="phone">Creada</th>
          </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repOrder" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <a href="<%# ResolveClientUrl("~/administracion/ordenes/" + Eval("OrderId"))%>">
                        <%# Eval("OrderId") %>
                        </a>
                    </td>
                    <td><asp:Label ID="lblCliente" runat="server" Text='<%# Eval("ClientName") %>'/></td>
                    <td><asp:Label ID="lblSubTotal" runat="server" Text='<%# Eval("SubTotal") %>'/></td>
                    <td><asp:Label ID="lblEstatus" runat="server" Text='<%# Eval("Status") %>'/></td>
                    <td><asp:Label ID="lblCreada" runat="server" Text='<%# Eval("CreationDate") %>'/></td>
                </tr>               
            </ItemTemplate>
        </asp:Repeater>
        </tbody>
        <tfoot>
		    <tr>
		    	<td colspan="5" class="text-center">
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
