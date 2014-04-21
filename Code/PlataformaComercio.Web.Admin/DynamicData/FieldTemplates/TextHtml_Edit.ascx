<%@ Control Language="C#" CodeBehind="TextHtml_Edit.ascx.cs" Inherits="PlataformaComercio.Web.Admin.DynamicData.FieldTemplates.TextHtml_EditField" %>
<%--<ighedit:WebHtmlEditor ID="WebHtmlEditor1" runat="server" Text='<%# FieldValueEditString %>'>
</ighedit:WebHtmlEditor>
--%>
<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="WebHtmlEditor1"
    Display="Dynamic" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="WebHtmlEditor1"
    Display="Dynamic" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" ControlToValidate="WebHtmlEditor1"
    Display="Dynamic" />