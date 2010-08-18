<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="AmxMobile.Services.Web.ViewUsers" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderContent">

    <h1>Manage Users</h1>
    <bfx:AutoDataGrid runat="server" id="gridUsers" allowadd="false" allowdelete="false" allowedit="false"></bfx:AutoDataGrid>
    
    <br />
    <asp:HyperLink runat="server" ID="linkAdd" Text="Add a new user..." NavigateUrl="~/viewuser.aspx?id=0"></asp:HyperLink>
    
</asp:Content>