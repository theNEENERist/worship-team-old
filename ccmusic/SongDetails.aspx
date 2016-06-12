﻿<%@ Page Title="Music Sheets" Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="SongDetails.aspx.cs" Inherits="ccmusic.SongDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function openTab(th)
        {
            if (screen.width > 600) {
                window.open(th.name, '_blank');
            }else {
                window.open(th.name, '#');
            }
        }
    </script>
    <div class="jumbotron">
        <h1>CCWorship</h1>
        <p class="lead"><asp:label runat="server" id="songTitle"/></p>
    </div>

    <div id="songFileList" runat="server">
        <div id="chordsList" runat="server">
            <label class="labels">Chords:</label>
        </div>
        <div id="lyricsList" runat="server" style="margin-top: 10px">
            <label class="labels">Lyrics:</label>
        </div>
    </div>
</asp:Content>