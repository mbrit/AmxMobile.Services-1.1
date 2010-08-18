<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewContentItemVersion.aspx.cs" Inherits="AmxMobile.Services.WebAdmin.ViewContentItemVersion" masterpagefile="~/MasterPages/RetailAdminMp.Master" ValidateRequest="false" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>
<%@ Register TagPrefix="cms" Assembly="BootFX.Cms.UI.WebControls" Namespace="BootFX.Cms.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderMpContent">
    <cms:contentitemversionview runat="server" id="widgetViewContentItemVersion"></cms:contentitemversionview>
</asp:Content>
