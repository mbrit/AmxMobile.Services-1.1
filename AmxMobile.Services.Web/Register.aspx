<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AmxMobile.Services.Web.Register" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="placeholderContent">

    <h1>Register</h1>
    <fieldset>
        <legend><span>Use this form to register for a new API account.</span></legend>
        <ol>
            <li>
                <label for="textUsername">Username</label>
                <asp:TextBox runat="server" ID="textUsername" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textPassword">Password</label>
                <asp:TextBox runat="server" ID="textPassword" TextMode="Password" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textConfirm">Confirm password</label>
                <asp:TextBox runat="server" ID="textConfirm" TextMode="Password" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textFirstname">First name</label>
                <asp:TextBox runat="server" ID="textFirstName" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textLastName">Last name</label>
                <asp:TextBox runat="server" ID="textLastName" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textCompany">Company</label>
                <asp:TextBox runat="server" ID="textCompany" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textAddress1">Address 1</label>
                <asp:TextBox runat="server" ID="textAddress1" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textAddress2">Address 2</label>
                <asp:TextBox runat="server" ID="textAddress2" MaxLength="48"></asp:TextBox>
            </li>
            <li>
                <label for="textAddress3">Address 3</label>
                <asp:TextBox runat="server" ID="textAddress3" MaxLength="48"></asp:TextBox>
            </li>
            <li>
                <label for="textCity">City/town</label>
                <asp:TextBox runat="server" ID="textCity" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="textRegion">Region/county</label>
                <asp:TextBox runat="server" ID="textRegion" MaxLength="48"></asp:TextBox>
            </li>
            <li>
                <label for="textPostalCode">Postal code/postcode</label>
                <asp:TextBox runat="server" ID="textPostalCode" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <label for="listCountry">Country</label>
                <asp:DropDownList runat="server" ID="listCountry"></asp:DropDownList>&nbsp;*
            </li>
            <li>
                <label for="textEmail">Email</label>
                <asp:TextBox runat="server" ID="textEmail" MaxLength="48"></asp:TextBox>&nbsp;*
            </li>
            <li>
                <asp:CheckBox runat="server" ID="checkSubscribe" Text="Send me occassional news and updates"></asp:CheckBox>
            </li>
            <li>
                <asp:Button runat="server" id="buttonSave" Text="Register Account" />
            </li>
        </ol>
    </fieldset>
    <bfx:UserFeedbackWidget runat="server" ID="widgetFeedback"></bfx:UserFeedbackWidget>

</asp:Content>