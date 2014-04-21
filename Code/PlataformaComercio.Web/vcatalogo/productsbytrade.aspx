<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true"
    CodeBehind="productsbytrade.aspx.cs" Inherits="PlataformaComercio.Web.vcatalogo.productsbytrade" %>

<%@ Register Src="~/webcontrols/ProductDisplay.ascx" TagName="ProductDisplay" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_title_bar"><h3><asp:Label ID="lblTrade" runat="server" Text=""></asp:Label></h3></div>
    <hr />
    <asp:ListView runat="server" ID="repProducts" ItemPlaceholderID="itemPlaceHolder">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            
          
        </LayoutTemplate>
        <ItemTemplate>
            <uc1:ProductDisplay ID="ProductDisplay1" runat="server" />
        </ItemTemplate>
    </asp:ListView>
    <div style="clear:both">
    <br />
      <asp:DataPager ID="DataPager1" runat="server" PagedControlID="repProducts" PageSize="9"
                class="NavegationBar">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Image" FirstPageImageUrl="~/images/paging/FirstHoverBoot.gif"
                        ShowFirstPageButton="true" PreviousPageImageUrl="~/images/paging/PreviousHoverBoot.gif"
                        ShowLastPageButton="false" ShowNextPageButton="false" />
                    <asp:NumericPagerField ButtonCount="10" />
                    <asp:NextPreviousPagerField ButtonType="Image" ShowLastPageButton="true" ShowNextPageButton="true"
                        ShowPreviousPageButton="false" LastPageImageUrl="~/images/paging/LastHoverBoot.gif"
                        NextPageImageUrl="~/images/paging/NextHoverBoot.gif" />
                </Fields>
            </asp:DataPager>
    </div>
</asp:Content>
