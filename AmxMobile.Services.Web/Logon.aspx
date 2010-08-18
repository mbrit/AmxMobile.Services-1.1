<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="AmxMobile.Services.Web.Logon" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content runat="server" ContentPlaceHolderID="placeholderContent">

    <h1>Logon</h1>
    <fieldset>
        <ol>
            <li>
                <label for="textUsername">Username</label>
                <asp:TextBox runat="server" ID="textUsername"></asp:TextBox>
            </li>
            <li>
                <label for="textUsername">Password</label>
                <asp:TextBox runat="server" ID="textPassword" TextMode="Password"></asp:TextBox>
            </li>
            <li>
                <asp:CheckBox runat="server" ID="checkRemember"  Text="Remember me" Checked="true" />
            </li>
            <li>
                <asp:Button runat="server" id="buttonLogon" Text="Logon" /> <asp:HyperLink runat="server" ID="linkForgot" text="Forgot password" NavigateUrl="~/forgot.aspx"></asp:HyperLink>
            </li>
        </ol>
    </fieldset>
    <bfx:UserFeedbackWidget runat="server" ID="widgetFeedback"></bfx:UserFeedbackWidget>

</asp:Content>