<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="AmxMobile.Services.Web.Forgot" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderContent">

    <h1>Forgotten Password</h1>
    <fieldset>
        <ol>
            <li>
                <label for="textEmail">Email</label>
                <asp:TextBox runat="server" ID="textEmail"></asp:TextBox>
            </li>
            <li>
                <asp:Button runat="server" id="buttonReset" Text="Reset Password" />
            </li>
        </ol>
    </fieldset>
    <bfx:UserFeedbackWidget runat="server" ID="widgetFeedback"></bfx:UserFeedbackWidget>

</asp:Content>