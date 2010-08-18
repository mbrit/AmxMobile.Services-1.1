<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewKey.aspx.cs" Inherits="AmxMobile.Services.Web.ViewKey" MasterPageFile="~/Master.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="placeholderContent">

    Use this key in your API requests:
    <br /><br />
    <asp:Label runat="server" ID="labelKey" CssClass="key"></asp:Label>

</asp:Content>