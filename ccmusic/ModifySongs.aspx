<%@ Page Title="Modify Songs" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ModifySongs.aspx.cs" Inherits="ccmusic.ModifySongs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CCWorship</h1>
        <p class="lead">Modify Songs</p>
    </div>

    <div class="ModifyLists">
        <div class="input-append date" id="dp3" data-date-format="mm-dd-yyyy">

        <div style="margin-bottom: 15px;"><span>Date: </span><input class="span2" runat="server" id="txtDate" size="16" type="text"></div>
        <asp:Button runat="server" OnClientClick="ShowPrevInnerPanel();" OnClick="GetSongsByUse" Text="Get Songs for Date" />

        <asp:GridView runat="server" ID="gvModifyList" EmptyDataText="No songs available" AutoGenerateColumns="false" OnRowDeleting="gvModifyList_Remove">
            <Columns>
                <asp:BoundField DataField="name" 
                    HeaderText="Name" ReadOnly="True"
                    SortExpression="name" />
                <asp:BoundField DataField="type" 
                    HeaderText="Type" InsertVisible="False"
                    ReadOnly="True" SortExpression="@type" />
                <asp:BoundField DataField="order" 
                    HeaderText="Order" InsertVisible="False"
                    ReadOnly="True" SortExpression="order" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
            </Columns>
        </asp:GridView>
    </div>

    <script type="text/javascript">
         $(document).ready(function () {
            var dp = $('#<%=txtDate.ClientID%>');
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "mm/dd/yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
            dp.datepicker('setDate', new Date());
        });
    </script>
</asp:Content>