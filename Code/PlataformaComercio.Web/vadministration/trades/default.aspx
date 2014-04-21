<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.trades._default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%# ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider">/</span>  
      </li>  
      <li class="active">
          Lista Marcas 
      </li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Lista de Marcas</h4>
    <hr />
    <%--<a href="<%= ResolveClientUrl("~/admin/trades/new") %>" class="btn btn-primary">Crear</a>
    <br />
    <dx:ASPxGridView ID="dvGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <dx:GridViewDataHyperLinkColumn Caption="Id" FieldName="TradeID" VisibleIndex="0">
                  <PropertiesHyperLinkEdit NavigateUrlFormatString="~/admin/trades/{0}">
                </PropertiesHyperLinkEdit>
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewDataTextColumn Caption="Name" FieldName="Name" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsPager PageSize="20">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
    </dx:ASPxGridView>--%>

    <table class="footable table table-bordered" data-filter="#filter" data-page-size="20" data-page-previous-text="prev" data-page-next-text="next">
        <thead>
          <tr>
              <th data-type="alpha">Id</th>
              <th data-type="alpha">Nombre</th>
          </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repTrades" runat="server">
            <ItemTemplate>
                <tr>
                    <td><asp:Label ID="lblID" runat="server" Text='<%# Eval("TradeID") %>'/></td> 
                    <td><asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Name") %>'/></td>
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
</asp:Content>
