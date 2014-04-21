<%@ Page Title="" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.currencys._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%#ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider"></span>  
      </li>  
      <li class="active">
          Tipo de Cambio 
      </li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Tipo de Cambio</h4>
    <hr />
    <asp:DataList ID="dtlCurrencys" runat="server" RepeatLayout="Flow">
        <ItemTemplate>
            <div  class="col-md-10">
                <h5 class="col-md-5"><%# Eval("Name") %></h5>
                <%--<a href="<%= ResolveClientUrl("~/administracion/tipodecambio/"+Eval("CurrencyId"))%>" class="btn btn-primary col-md-2">Editar</a>--%>
                <a href="<%#ResolveClientUrl("~/administracion/tipodecambio/"+ Eval("CurrencyId"))%>" class="btn btn-primary col-md-2">Editar</a>
            </div>
            <%--<a href="addoreditcurrency.aspx?CurrencyId=<%# Eval("CurrencyId")%>"><%# Eval("Name")%></a>--%>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
