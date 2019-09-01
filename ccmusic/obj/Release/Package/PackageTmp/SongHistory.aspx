<%@ Page Title="Song History" Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="SongHIstory.aspx.cs" Inherits="ccmusic.SongHistory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CCWorship</h1>
        <p class="lead"></p>
    </div>
    <div class="wouldYouOuter">
        <div id="wouldYou">
            <h1>Would you rather:</h1>
            <input type="button" id="btnAddSongs" value="Add New Songs" />
            <input type="button" id="btnViewPrevious" value="View Previous Songs" />
        </div>
        <div id="addNewSongs" style="display:none">
            <div class="input-append date" id="dp3" data-date-format="mm-dd-yyyy">
                <asp:panel runat="server">
                    <div id="newSong">
                        <span id="success" style="color: #00cc00;display:none;padding-bottom:5px;">The songs have been succesfully added.</span>
                        <div style="margin-bottom: 15px;"><span>Date: </span><input class="span2" runat="server" id="txtDate" size="16" type="text"></div>
                        <div style="margin-top: 10px" class="songDiv">
                            <span>Song Name: </span><input class="songsUsed" type="text">
                            <br />
                            <div style="padding-top:10px">
                                <select class="songType">
                                    <option value="-1">Song Type</option>
                                    <option value="Worship">Worship</option>
                                    <option value="Communion">Communion</option>
                                    <option value="Invitation">Invitation</option>
                                    <option value="Closing">Closing</option>
                                </select>
                            </div>

                            <div style="padding-top:10px;">
                                <select class="songOrder">
                                    <option value="-1">Order</option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                    <option value="14">14</option>
                                    <option value="15">15</option>
                                </select>
                            </div>
                        </div>
                        <span class="add-on"><i class="icon-th"></i></span>
                        <div runat="server" class="songTxts" />
                    </div>

                    <div style="margin-top: 15px">
                        <input type="button" onclick="AddSongTxt();" value="Add Another Song">
                        <input type="button" id="btnSubmit" value="Submit Songs" />
                    </div>
                </asp:panel>
            </div>
            <div class="back" style="padding-top: 15px;">
                <input type="button" id="btnNewBack" value="&lArr; Back" />
            </div>
        </div>
        <div id="viewPreviousSongs" style="display:none">
            <div class="input-append date" id="dp2" data-date-format="mm-dd-yyyy">
                <asp:panel runat="server">
                    <div id="previousSong">
                        <div style="margin-bottom: 15px;"><span>Date: </span><input class="span2" runat="server" id="txtPrevDate" size="16" type="text"></div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button runat="server" OnClientClick="ShowPrevInnerPanel();" OnClick="GetSongsByUse" Text="Get Songs for Date" />

                                    <div id="prevInner" class="previous" runat="server">
                                        <div>
                                        <h4>Songs for <span id="prevDate" runat="server"></span></h4>
                                        <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Worship">
                                            <asp:BulletedList runat="server" ID="blPrevWorship"/>
                                        </asp:Panel>
                                        <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Communion">
                                            <asp:BulletedList runat="server" ID="blPrevCommunion"/>
                                        </asp:Panel>
                                        <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Invitation">
                                            <asp:BulletedList runat="server" ID="blPrevInvitation"/>
                                        </asp:Panel>
                                        <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Closing">
                                            <asp:BulletedList runat="server" ID="blPrevClosing"/>
                                        </asp:Panel>
                                            </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="back" style="padding-top: 15px;">
                                <input type="button" id="btnPrevBack" value="&lArr; Back" />
                            </div>
                        </div>
                    </div>
                </asp:panel>
            </div>
        </div>
    </div>
    <div class="upcomingSongs">
        <asp:UpdatePanel runat="server" ID="upUpcoming">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="btnUpcoming" eventname="Click" />
            </Triggers>
            <ContentTemplate>
                <div class="upcomingInner" style="padding-left: 10px;">
                    <h4>Songs for Next Week (<span runat="server" id="nextDate"></span>):</h4>
                    <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Worship">
                        <asp:BulletedList runat="server" ID="blWorship"/>
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Communion">
                        <asp:BulletedList runat="server" ID="blCommunion"/>
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Invitation">
                        <asp:BulletedList runat="server" ID="blInvitation"/>
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="pnlUpcomingMusic" GroupingText="Closing">
                        <asp:BulletedList runat="server" ID="blClosing"/>
                    </asp:Panel>
                    <asp:Button runat="server" ID="btnUpcoming" OnClick="UpdateUpcoming" style="display:none"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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
           var newItem = $("<div style='margin-top: 5px' class='songDiv'><div style='width:300px;'><hr/></div><span>Song Name: </span><input class='songsUsed' type='text'><br /><div style='padding-top:5px'><select class='songType'><option value='-1'>Song Type</option><option value='Worship'>Worship</option>                                <option value='Communion'>Communion</option><option value='Invitation'>Invitation</option><option value='Closing'>Closing</option></select></div><div style='padding-top:10px;'><select class='songOrder'><option value='-1'>Order</option><option value='1'>1</option><option value='2'>2</option><option value='3'>3</option><option value='4'>4</option><option value='5'>5</option><option value='6'>6</option><option value='7'>7</option><option value='8'>8</option<option value='9'>9</option><option value='10'>10</option><option value='11'>11</option><option value='12'>12</option><option value='13'>13</option><option value='14'>14</option><option value='15'>15</option></select></div></div>");

           $('.songTxts').append(newItem);

           $('.songsUsed').each(function () {
               $(this).autocomplete({
                   source: songs
               });
           });
       }

       $('#btnAddSongs').click(function (e) {
           $('#addNewSongs').show();
           $('#viewPreviousSongs').hide();
           $('#wouldYou').hide();
       });
       
       $('#btnNewBack,#btnPrevBack').click(function (e) {
           $('#addNewSongs').hide();
           $('#viewPreviousSongs').hide();
           $('#wouldYou').show();
       });
       
       $('#btnViewPrevious').click(function (e) {
           $('#addNewSongs').hide();
           $('#viewPreviousSongs').show();
           $('#wouldYou').hide();
       });
       
       $('#btnSubmit').click(function (e) {
            var isValid = true;
            $('.songsUsed').each(function () {
                if ($.trim($(this).val()) == '') {
                    isValid = false;
                    $(this).css({
                        "border": "1px solid red",
                        "background": "#FFCECE"
                    });
                } 
                else {
                    $(this).css({
                        "border": "",
                        "background": ""
                    });
                }
            });
            $('.songType').each(function () {
                if ($(this).val() == -1) {
                    isValid = false;
                    $(this).css({
                        "border": "1px solid red",
                        "background": "#FFCECE"
                    });
                }
            });
            $('.songOrder').each(function () {
                if ($(this).val() == -1) {
                    isValid = false;
                    $(this).css({
                        "border": "1px solid red",
                        "background": "#FFCECE"
                    });
                }
            });

           if (isValid == false)
               e.preventDefault();

           SubmitSongs();
       });

       $('.songsUsed').keyup(function () {
           $(this).css({
               "border": "",
               "background": ""
           });
           $('#success').hide();
       });

       $('.songsUsed').focusout(function () {
           if ($.inArray($(this).val(), songs) == -1 && $(this).val() != '') {
               alert("This song is not currently uploaded to the website.  Are you sure you want to use this song?")
           }
       });

       $('.songType, .songOrder').change(function () {
           if($(this).val() !== -1)
               $(this).css({
                   "border": "",
                   "background": ""
               });
           $('#success').hide();
       });
       
       function SubmitSongs() {
           var songs = [];
           var date = $('#<%=txtDate.ClientID%>');

           $('.songDiv').each(function () {
               var song = new Object();
               song.name = $(this).find('.songsUsed').val()
               song.type = $(this).find('.songType').val();
               song.order = $(this).find('.songOrder').val();
               song.date = date.val();
               songs.push(song);
           });

           songs = JSON.stringify({
               'songs': songs
           })
           $.ajax({
               type: "POST",
               dataType: "json",
               contentType: "application/json; charset=utf-8",
               url: "SongHistory.aspx/SaveSongs",
               data: songs,
               success: function (msg) {
                   $('#success').show();
                   $('#<%=btnUpcoming.ClientID%>').click();
               },
               error: function (msg) { }
           });
       }
        /************************************************
            Datepicker
        ************************************************/
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

            var dp2 = $('#<%=txtPrevDate.ClientID%>');
            dp2.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "mm/dd/yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
            dp2.datepicker('setDate', new Date());
        });
    </script>
</asp:Content>