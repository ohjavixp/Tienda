<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageControl.ascx.cs" Inherits="PlataformaComercio.Web.webcontrols.MessageControl" EnableViewState="false" %>
<asp:Panel ID="pnlHighLight" CssClass="ui-widget" runat="server" Visible="false">
    <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;"> 
		<p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
		<strong>Advertencia</strong> <%= Message%></p>
	</div>
</asp:Panel>

<asp:Panel ID="pnlError" CssClass="ui-widget" runat="server" Visible="false">
    <div class="ui-state-error ui-corner-all" style="padding: 0 .7em;">
        <p>
            <span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span>
            <strong>Error:</strong> <%= Message%>
        </p>
    </div>
</asp:Panel>

	


