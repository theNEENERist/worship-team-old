<%@ Page Title="File Upload" Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="ccmusic.FileUpload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CCWorship</h1>
        <p class="lead"></p>
    </div>
    <div style="margin-bottom: 5px;">
        <asp:Label Text="File Type: " runat="server" />
        <asp:DropDownList ID="songType" runat="server">
            <asp:ListItem Text="Chords" Value="1" />
            <asp:ListItem Text="Sheet Music" Value="2" />
            <asp:ListItem Text="Lyrics" Value="3" />
        </asp:DropDownList>
    </div>
    <div style="margin-bottom: 5px;">
        <asp:Label Text="Song Name: " runat="server" />
        <asp:TextBox ID="fileName" runat="server" />
    </div>
    <asp:FileUpload runat="server" ID="upload" style="margin-bottom: 20px;"/>
    <asp:Button Text="Upload" OnClick="UploadFile" runat="server"/>
</asp:Content>