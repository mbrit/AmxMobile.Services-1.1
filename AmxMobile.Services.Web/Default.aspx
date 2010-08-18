<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AmxMobile.Services.Web._Default" MasterPageFile="~/Master.Master" %>

<asp:content runat="server" ContentPlaceHolderID="placeholderContent">

    <b>Welcome to the multimobiledevelopment.com Six Bookmarks Service Test Platform</b>
    <br /><br />

    <asp:Panel runat="server" id="panelAccounts">
        <fieldset>
            <legend><span>Accounts</span></legend>
            <ol>
                <li><asp:HyperLink runat="server" ID="linkLogon" text="Logon to your API account" NavigateUrl="~/logon.aspx"></asp:HyperLink></li>
                <li><asp:HyperLink runat="server" ID="linkRegister" text="Register a new API account" NavigateUrl="~/register.aspx"></asp:HyperLink></li>
            </ol>
        </fieldset>
    </asp:Panel>

    <asp:Panel runat="server" id="panelOptions">
        <fieldset>
            <legend><span>Options</span></legend>
            <ol>
                <li><asp:HyperLink runat="server" ID="linkViewProfile" text="Edit your account profile" NavigateUrl="~/viewprofile.aspx"></asp:HyperLink></li>
                <li><asp:HyperLink runat="server" ID="linkUsers" text="Manage users" NavigateUrl="~/viewusers.aspx"></asp:HyperLink></li>
            </ol>
        </fieldset>
    </asp:Panel>

    <fieldset>
        <legend><span>Services</span></legend>
        <ol>
            <li>API REST Web service  - <b>http://services.multimobiledevelopment.com/Services/ApiRest.aspx</b> - 
                <asp:HyperLink runat="server" ID="HyperLink3" NavigateUrl="http://code.google.com/p/sixbookmarks/wiki/ApiWebService" Text="Documentation"></asp:HyperLink></li>
            <li>Users REST Web service  - <b>http://services.multimobiledevelopment.com/Services/UsersRest.aspx</b> - 
                <asp:HyperLink runat="server" ID="linkDocumentation" NavigateUrl="http://code.google.com/p/sixbookmarks/wiki/UsersWebService" Text="Documentation"></asp:HyperLink></li>
            <li>Bookmarks OData service - <b>http://services.multimobiledevelopment.com/Services/Bookmarks.svc</b> - 
                <asp:HyperLink runat="server" ID="linkBookmarksDocumentation" NavigateUrl="http://code.google.com/p/sixbookmarks/wiki/BookmarksWebService" Text="Documentation"></asp:HyperLink></li>
        </ol>
    </fieldset>
    
    <fieldset>
        <legend><span>The Book</span></legend>
        <ol>
            <li><a href="http://www.multimobiledevelopment.com/"><img src="http://www.multimobiledevelopment.com/images/coversmall.png" align="left" style="padding-right:10px" border="0" /></a>Visit <a href="http://www.multimobiledevelopment.com/">http://www.multimobiledevelopment.com/</a> for
            code downloads and other community resources and support.</li>
        </ol>
    </fieldset>


</asp:content>