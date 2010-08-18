<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMediaRepositories.aspx.cs" Inherits="AmxMobile.Services.WebAdmin.ViewMediaRepositories" masterpagefile="~/MasterPages/RetailAdminMp.Master"  %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>
<%@ Register TagPrefix="cms" Assembly="BootFX.Cms.UI.WebControls" Namespace="BootFX.Cms.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderMpContent">
    <cms:MediaRepositoriesView runat="server" ID="widgetRepositories"></cms:MediaRepositoriesView>
</asp:Content>
