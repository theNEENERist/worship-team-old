<%@ Page Title="Song History" Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="SongHIstory.aspx.cs" Inherits="ccmusic.SongHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CCWorship</h1>
        <p class="lead"></p>
    </div>
    <div style="margin-bottom: 5px;">
        <div class="input-append date" id="dp3" data-date="12-02-2012" data-date-format="dd-mm-yyyy">
          <input class="span2" runat="server" id="dateTextBox" size="16" type="text" value="12-02-2012">
          <span class="add-on"><i class="icon-th"></i></span>
        </div>
    </div>
    <div style="margin-bottom: 5px;">
        <asp:Label Text="Song Name: " runat="server" />
        <asp:TextBox ID="fileName" runat="server" />
    </div>
    <script type="text/javascript">
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
            format: "dd.mm.yyyy",
            language: "tr"
        }).on('changeDate', function (ev) {
            $(this).blur();
            $(this).datepicker('hide');
        });
});
    </script>
</asp:Content>