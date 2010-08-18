<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="AmxMobile.Services.Web.ViewUser" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderContent">

    <h1>Edit User - <asp:Label runat="server" ID="labelUser"></asp:Label></h1>
    
    <fieldset>
        <legend><span>Details</span></legend>
        <ol>
            <li>
                <label for="textUsername">Username</label>
                <asp:TextBox runat="server" ID="textUsername" MaxLength="32"></asp:TextBox>
            </li>
            <li>
                <label for="textEmail">Email</label>
                <asp:TextBox runat="server" ID="textEmail" MaxLength="48"></asp:TextBox>
            </li>
            <li><asp:CheckBox runat="server" ID="checkChangePassword" text="Change password" AutoPostBack="true" /></li>
            <asp:Panel runat="server" ID="panelPassword" Visible="false">
                <li>
                    <label for="textPassword">Password</label>
                    <asp:TextBox runat="server" ID="textPassword" TextMode="Password" MaxLength="32"></asp:TextBox>
                </li>
                <li>
                    <label for="textConfirm">Confirm</label>
                    <asp:TextBox runat="server" ID="textConfirm" TextMode="Password" MaxLength="32"></asp:TextBox>
                </li>
            </asp:Panel>
            <li><asp:CheckBox runat="server" ID="checkIsActive" text="Is active" /></li>
            <li><asp:button runat="server" ID="buttonSave" Text="Save Changes" /></li>
        </ol>
    </fieldset>
    <bfx:UserFeedbackWidget runat="server" ID="widgetFeedback"></bfx:UserFeedbackWidget>
    
    <asp:panel runat="server" ID="panelBookmarks">
    
        <asp:HyperLink runat="server" ID="linkBookmarks" Text="Manage this user's bookmarks..."></asp:HyperLink>
    
    </asp:panel>

</asp:Content>