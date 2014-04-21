<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/vadministration/BootAdministration.Master"
    AutoEventWireup="true" CodeBehind="inventory-category.aspx.cs" Inherits="PlataformaComercio.Web.vadministration.inventory.inventory_category" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="breadcrumb" runat="server">
    <ul class="breadcrumb">  
      <li>  
        <a href="<%#ResolveClientUrl("~/administracion") %>">Inicio</a> <span class="divider"></span>  
      </li>  
      <li class="active">
          Categorias
      </li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Categorias</h4>
    <hr />  
    <asp:TreeView ID="trvCategories" runat="server" OnTreeNodePopulate="trvCategories_TreeNodePopulate"
        OnSelectedNodeChanged="trvCategories_SelectedNodeChanged">
    </asp:TreeView>
    <br />

    <asp:PlaceHolder runat="server" ID="phCategoryDetail" Visible="false">
        <h4>Información de categoría <b><asp:Label ID="lblCategoryName" runat="server"/></b></h4>
        <br />
        <asp:Button ID="btnNew" runat="server" Text="Nueva Sub Categoria" OnClick="btnNew_Click" CssClass="btn btn-small disabled" Enabled="false"/>
            
        <br />      
        <br />                    
        <h4>Sub Categorias</h4>
        <hr />                                  
        <%--<dx:ASPxGridView ID="dvGridCategories" runat="server" AutoGenerateColumns="False" KeyFieldName="CategoryID"
            OnCustomButtonCallback="dvGridCategories_CustomButtonCallback" ClientInstanceName="gridCategories" EnableCallBacks="False">             
            <Columns>
                <dx:GridViewDataTextColumn Caption="Nombre" FieldName="Name" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Descripción" FieldName="ShortDescription" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="2">
                    <ClearFilterButton Visible="True">
                    </ClearFilterButton>
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnUpdateCategory" Text="Editar">
                        </dx:GridViewCommandColumnCustomButton>
                        <dx:GridViewCommandColumnCustomButton ID="btnDeleteCategory" Text="Eliminar">
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
        </dx:ASPxGridView> --%>
        
        <table class="footable table table-bordered" data-filter="#filter" data-page-size="20" data-page-previous-text="prev" data-page-next-text="next">
            <thead>
              <tr>
                  <th data-type="alpha">Nombre</th>
                  <th data-type="alpha">Descripción</th>
              </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="repGridCategories" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><asp:Label ID="lblID" runat="server" Text='<%# Eval("Name") %>'/></td> 
                        <td><asp:Label ID="lblCliente" runat="server" Text='<%# Eval("ShortDescription") %>'/></td>
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
                           
        <asp:Label ID="lblAction" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:PlaceHolder ID="plhAction" runat="server" Visible="false">
                
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtName" CssClass="col-md-2 control-label">Nombre:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtShortDescription" CssClass="col-md-2 control-label">Descripción Corta:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtShortDescription" TextMode="MultiLine" Rows="2" CssClass="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtLargeDescription" CssClass="col-md-2 control-label">Descripcion Larga:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtLargeDescription" TextMode="MultiLine" Rows="5" CssClass="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOrder" CssClass="col-md-2 control-label">Orden:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtOrder" CssClass="form-control"/>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <div class="checkbox"><asp:CheckBox runat="server" ID="chkIsActive" Text="Activa"/></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <div class="checkbox"><asp:CheckBox runat="server" ID="chkShow" Text="Show"/></div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-md-10">
                            <asp:Button ID="btnAction" runat="server" Text="" OnCommand="btnAction_Command"/>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

        <h4>Productos asociados a la categoria</h4>
        <div class="input-append">
            <div class="form-inline">
                <div class="form-group">
                    <asp:TextBox ID="txtSku" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnAddProduct" runat="server" CssClass="btn btn-primary" Text="Agregar Producto" OnClick="btnAddProduct_Click" />
                </div>
            </div>
        </div>
            <br />
        <%--<dx:ASPxGridView ID="dvGridCategoryProducts" runat="server" AutoGenerateColumns="False" OnRowDeleting="dvGridCategoryProducts_RowDeleting" KeyFieldName="SKU">
            <Columns>
                <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0">
                    <DeleteButton Visible="True">
                    </DeleteButton>
                </dx:GridViewCommandColumn>
                <dx:GridViewDataHyperLinkColumn Caption="SKU" FieldName="SKU" ShowInCustomizationForm="True" VisibleIndex="1">
                </dx:GridViewDataHyperLinkColumn>
                <dx:GridViewDataTextColumn Caption="Name" FieldName="Name" ShowInCustomizationForm="True" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>--%>
        <table class="footable table table-bordered" data-filter="#filter" data-page-size="20" data-page-previous-text="prev" data-page-next-text="next">
        <thead>
          <tr>
              <th data-type="alpha">Id Producto</th>
              <th data-type="alpha">Nombre</th>
          </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="repCategoryProduct" runat="server">
            <ItemTemplate>
                <tr>
                    <td><asp:Label ID="lblID" runat="server" Text='<%# Eval("SKU") %>'/></td> 
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
    </asp:PlaceHolder>

</asp:Content>