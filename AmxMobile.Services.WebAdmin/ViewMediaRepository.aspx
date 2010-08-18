<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMediaRepository.aspx.cs" Inherits="AmxMobile.Services.WebAdmin.ViewMediaRepository" masterpagefile="~/MasterPages/RetailAdminMp.Master"  %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>
<%@ Register TagPrefix="cms" Assembly="BootFX.Cms.UI.WebControls" Namespace="BootFX.Cms.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderMpContentNoAjax">
    <cms:MediaRepositoryView runat="server" ID="widgetRepository"></cms:MediaRepositoryView>
</asp:Content>
