<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewContentItems.aspx.cs" Inherits="AmxMobile.Services.WebAdmin.ViewContentItems" masterpagefile="~/MasterPages/RetailAdminMp.Master"  %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>
<%@ Register TagPrefix="cms" Assembly="BootFX.Cms.UI.WebControls" Namespace="BootFX.Cms.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderMpContent">
    <cms:contentitemsview runat="server" id="widgetViewContentItems"></cms:contentitemsview>
</asp:Content>
