<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewContentItem.aspx.cs" Inherits="AmxMobile.Services.WebAdmin.ViewContentItem" masterpagefile="~/MasterPages/RetailAdminMp.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>
<%@ Register TagPrefix="cms" Assembly="BootFX.Cms.UI.WebControls" Namespace="BootFX.Cms.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderMpContent">
    <cms:contentitemview runat="server" id="widgetViewContentItem"></cms:contentitemview>
</asp:Content>
