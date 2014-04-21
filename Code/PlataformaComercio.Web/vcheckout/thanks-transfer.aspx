<%@ Page Title="" Language="C#" MasterPageFile="~/PrincipalBootstrap.Master" AutoEventWireup="true" CodeBehind="thanks-transfer.aspx.cs" Inherits="PlataformaComercio.Web.vcheckout.thanks_transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="center_content">
   	<h3>Confirmación de Orden</h3>
    <hr />
    <h4 class="text-center">Gracias por su compra</h4>
    <p>
        <br />
        Se ha generado la órden número: <asp:Label runat="server" ID="lblOrderNumber"/>
                &nbsp Para poder procesar su pedido cuenta con 2 dias para realizar el deposito o transferencia bancaria por la cantidad de 
                <span class="price"><asp:Label runat="server" ID="lblTotalOrder"/></span> a:                
                <br />           
                <br />           
                <br />                 
                    <label class="FirstLabel">Banco :</label>                    
                    BBVA Bancomer <br />
                    <label class="FirstLabel">Beneficiario :</label>
                    Biometria Aplicada S.A. de C.V. <br />
                    <label class="FirstLabel">Pesos Mexicanos :</label>
                    Cuenta No.: 0452754630 Clave Interbancaria: 012 180 00452754630 4<br />
                    <label class="FirstLabel">Dolares :</label>  
                    Cuenta No.:0135828384 Clave Interbancaria: 012 180 00135828384 <br />
    </p>
</asp:Content>
