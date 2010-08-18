<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AmxMobile.Services.Web.Error" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content runat="server" ContentPlaceHolderID="placeholderContent">

    <bfx:WebErrorWidget runat="server" ID="widgetError"></bfx:WebErrorWidget>

</asp:Content>