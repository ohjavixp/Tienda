<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PlataformaComercio.Web.Default" %>
<%@ Register src="webcontrols/ProductDisplay.ascx" tagname="ProductDisplay" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphCarousel" runat="server">
    <div class="row carousel-holder">
                    <div class="col-md-12">
                        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                            <ol class="carousel-indicators">
                                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                                <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                            </ol>
                            <div class="carousel-inner">
                                <div class="item active">
                                    <img class="slide-image" src="images/Slider/DEMO-5.png"/>
                                </div>
                                <div class="item">
                                    <img class="slide-image" src="images/Slider/DEMO-4.png"/>
                                </div>
                                <div class="item">
                                    <img class="slide-image" src="images/Slider/DEMO-3.png"/>
                                </div>
                                <div class="item">
                                    <img class="slide-image" src="images/Slider/DEMO-2.png"/>
                                </div>
                            </div>
                            <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left"></span>
                            </a>
                            <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right"></span>
                            </a>
                        </div>
                    </div>
                </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <h4>Productos Recientes</h4>
        <hr />
        <asp:Repeater runat="server" ID="repNewProducts">
            <ItemTemplate>
                <uc1:ProductDisplay ID="ProductDisplay1" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
    <div class="row">
        <h4>Productos Recomendados</h4>
        <hr />
        <asp:Repeater runat="server" ID="repRecommendedProducts">
            <ItemTemplate>
                <uc1:ProductDisplay ID="ProductDisplay1" runat="server" />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
