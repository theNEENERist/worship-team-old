<%@ Page Title="Song History" Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="SongHIstory.aspx.cs" Inherits="ccmusic.SongHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CCWorship</h1>
        <p class="lead"></p>
    </div>
    <div style="margin-bottom: 5px;">
        <div class="input-append date" id="dp3" data-date-format="dd-mm-yyyy">
            <asp:panel runat="server">
                <div id="newSong">
                    <input class="span2" runat="server" id="dateTextBox" size="16" type="text">
                    <input class="songsUsed" size="80" type="text">
                    <span class="add-on"><i class="icon-th"></i></span>
                    <div runat="server" class="songTxts" />
                    <input type="button" onclick="AddSongTxt();" value="Add Another Song">
                    <asp:Button runat="server" Text="Submit" OnClick="SubmitSongs" />
                </div>

                <div id="pastSongs">
                    <asp:Button runat="server" Text="Submit" OnClick="GetSongsByDate" />
                </div>
            </asp:panel>
        </div>
    </div>
    <div style="margin-bottom: 5px;">
        <asp:Label Text="Song Name: " runat="server" />
        <asp:TextBox ID="fileName" runat="server" />
    </div>
    <div class="row" id="songListContainer" runat="server">
    </div>
    <script type="text/javascript">
        var songs = $.parseJSON('<%= songsJson %>');

        $(function () {
            $('.songsUsed').each( function() {
                $(this).autocomplete({
                    source: songs
                });
            });
        });

       function AddSongTxt() {

           var newItem = $("<input type='text' class='songsUsed' size='80' />");
           //var newItem = $("<input type='text' name='td_products[" + counter + "]' />");


           $(".songTxts").append(newItem);

           $('.songsUsed').each(function () {
               $(this).autocomplete({
                   source: songs
               });
           });

           //newItem.find('input').autocomplete({source: songs});
       }
        /*var nowTemp = new Date();
        var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

        var checkin = $('#dpd1').datepicker({
            onRender: function (date) {
                return date.valueOf() < now.valueOf() ? 'disabled' : '';
            }
        }).on('changeDate', function (ev) {
            if (ev.date.valueOf() > checkout.date.valueOf()) {
                var newDate = new Date(ev.date)
                newDate.setDate(newDate.getDate() + 1);
                checkout.setValue(newDate);
            }
            checkin.hide();
            $('#dpd2')[0].focus();
        }).data('datepicker');
        var checkout = $('#dpd2').datepicker({
            onRender: function (date) {
                return date.valueOf() <= checkin.date.valueOf() ? 'disabled' : '';
            }
        }).on('changeDate', function (ev) {
            checkout.hide();
        }).data('datepicker');*/

         $(document).ready(function () {
        var dp = $('#<%=dateTextBox.ClientID%>');
        dp.datepicker({
            changeMonth: true,
            changeYear: true,
            format: "dd-mm-yyyy",
            language: "tr"
        }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });
        dp.datepicker('setDate', new Date());
});
    </script>
</asp:Content>