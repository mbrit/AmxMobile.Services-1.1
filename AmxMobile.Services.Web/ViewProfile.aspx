<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="AmxMobile.Services.Web.ViewProfile" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderContent">

    <h1>Account Profile</h1>
    
    <fieldset>
        <legend><span>Change Email Address</span></legend>
        <ol>
            <li>
                <label for="textEmail">Email</label>
                <asp:TextBox runat="server" ID="textEmail"></asp:TextBox>
            </li>
            <li>
                <asp:Button runat="server" id="buttonEmail" Text="Change Email Address" />
            </li>
        </ol>
    </fieldset>
    <bfx:UserFeedbackWidget runat="server" ID="widgetEmailFeedback"></bfx:UserFeedbackWidget>
    <br />
    
    <fieldset>
        <legend><span>Change Password</span></legend>
        <ol>
            <li>
                <label for="textPassword">Password</label>
                <asp:TextBox runat="server" ID="textPassword" TextMode="Password"></asp:TextBox>
            </li>
            <li>
                <label for="textConfirm">Confirm</label>
                <asp:TextBox runat="server" ID="textConfirm" TextMode="Password"></asp:TextBox>
            </li>
            <li>
                <asp:Button runat="server" id="buttonPassword" Text="Change Password" />
            </li>
        </ol>
    </fieldset>
    <bfx:UserFeedbackWidget runat="server" ID="widgetPasswordFeedback"></bfx:UserFeedbackWidget>

</asp:Content>