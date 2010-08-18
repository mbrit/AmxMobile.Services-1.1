<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBookmarks.aspx.cs" Inherits="AmxMobile.Services.Web.ViewBookmarks" MasterPageFile="~/Master.Master" %>
<%@ Register TagPrefix="bfx" Assembly="BootFX.Common.UI.Web" Namespace="BootFX.Common.UI.Web" %>

<asp:Content runat="server" ContentPlaceHolderID="placeholderContent">

    <h1>Edit Bookmarks - <asp:Label runat="server" ID="labelUser"></asp:Label></h1>

    <fieldset>
        <legend><span>Bookmark 1</legend>
        <ol>
            <li><label for="textName">Name</label>
            <asp:TextBox runat="server" ID="textName1" Width="400px"></asp:TextBox></li>
        </ol>
        <ol>
            <li><label for="textUrl">Url</label>
            <asp:TextBox runat="server" ID="textUrl1" Width="400px"></asp:TextBox></li>
        </ol>
    </fieldset>
    
    <fieldset>
        <legend><span>Bookmark 2</legend>
        <ol>
            <li><label for="textName">Name</label>
            <asp:TextBox runat="server" ID="textName2" Width="400px"></asp:TextBox></li>
        </ol>
        <ol>
            <li><label for="textUrl">Url</label>
            <asp:TextBox runat="server" ID="textUrl2" Width="400px"></asp:TextBox></li>
        </ol>
    </fieldset>
    
    <fieldset>
        <legend><span>Bookmark 3</legend>
        <ol>
            <li><label for="textName">Name</label>
            <asp:TextBox runat="server" ID="textName3" Width="400px"></asp:TextBox></li>
        </ol>
        <ol>
            <li><label for="textUrl">Url</label>
            <asp:TextBox runat="server" ID="textUrl3" Width="400px"></asp:TextBox></li>
        </ol>
    </fieldset>
    
    <fieldset>
        <legend><span>Bookmark 4</legend>
        <ol>
            <li><label for="textName">Name</label>
            <asp:TextBox runat="server" ID="textName4" Width="400px"></asp:TextBox></li>
        </ol>
        <ol>
            <li><label for="textUrl">Url</label>
            <asp:TextBox runat="server" ID="textUrl4" Width="400px"></asp:TextBox></li>
        </ol>
    </fieldset>
    
    <fieldset>
        <legend><span>Bookmark 5</legend>
        <ol>
            <li><label for="textName">Name</label>
            <asp:TextBox runat="server" ID="textName5" Width="400px"></asp:TextBox></li>
        </ol>
        <ol>
            <li><label for="textUrl">Url</label>
            <asp:TextBox runat="server" ID="textUrl5" Width="400px"></asp:TextBox></li>
        </ol>
    </fieldset>
    
    <fieldset>
        <legend><span>Bookmark 6</legend>
        <ol>
            <li><label for="textName">Name</label>
            <asp:TextBox runat="server" ID="textName6" Width="400px"></asp:TextBox></li>
        </ol>
        <ol>
            <li><label for="textUrl">Url</label>
            <asp:TextBox runat="server" ID="textUrl6" Width="400px"></asp:TextBox></li>
        </ol>
    </fieldset>
    
    <asp:Button runat="server" ID="buttonSave" Text="Save Changes" />
    <bfx:UserFeedbackWidget runat="server" ID="widgetFeedback"></bfx:UserFeedbackWidget>

</asp:Content>