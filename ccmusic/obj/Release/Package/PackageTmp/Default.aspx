<%@ Page Title="CCMusic" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ccmusic._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    $(document).ready(function () {
        $("#txtFilter").on("keyup", function () {
            var search = this.value;
            $(".searchable").each(function () {
                a = this; if (a.innerText.toLowerCase().startsWith(search.toLowerCase()))
                    this.hidden = false
                else
                    this.hidden = true
            });

        })
    });
</script>
<div class="jumbotron">
    <h1>CCMusic</h1>
    <p class="lead"></p>
</div>

<div id="filter">
    <%--<asp:TextBox runat="server" ID="txtFilter" />--%>
    <asp:Label runat="server" Text="Search: " class="labels"/><input type="text" id="txtFilter">
</div>
    <%--<asp:LinkButton ID="songListCall" runat="server" OnClick="linkBtnClick" Text="Click Me!"/>--%>
<div class="row" id="songListContainer" runat="server">
    <%--<div class="col-md-3 songListOutter">
        <a href="#" runat="server" onclick="LinkOnClick">
            <div class="songList">
                <h3>Blessed be the Name</h3>
            </div>
        </a>
    </div>--%>
</div>

</asp:Content>
