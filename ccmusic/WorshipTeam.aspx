<%@ Page Title="Worship Team" Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="WorshipTeam.aspx.cs" Inherits="ccmusic.WorshipTeam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>CCWorship</h1>
        <p class="lead"></p>
    </div>
    <div class="wouldYouOuter">
        <div id="wouldYou">
            <h1>Would you rather:</h1>
            <input type="button" id="btnAddTeam" value="Add New Worship Team" />
            <input type="button" id="btnViewPrevious" value="View Worship Team" />
        </div>
        <div id="addNewTeam" style="display:none">
            <div class="input-append date" id="dp3" data-date-format="mm-dd-yyyy">
                <asp:panel runat="server">
                    <div id="newTeam">
                        <span id="success" style="color: #00cc00;display:none;padding-bottom:5px;">The team has been succesfully added.</span>
                        <div style="margin-bottom: 15px;"><span>Date: </span><input class="span2" runat="server" id="txtDate" size="16" type="text"></div>
                        <div style="margin-top: 10px" class="teamDiv">
                            <span>Member: </span><input class="teamMembers" type="text">
                            <br />
                            <div style="padding-top:10px">
                                <select class="roleType">
                                    <option value="-1">Member Role</option>
                                    <option value="Singer">Singer</option>
                                    <option value="Musician">Musician</option>
                                </select>
                            </div>
                        </div>
                        <span class="add-on"><i class="icon-th"></i></span>
                        <div runat="server" class="memberTxts" />
                    </div>

                    <div style="margin-top: 15px">
                        <input type="button" onclick="AddMemberTxt();" value="Add Another Member">
                        <input type="button" id="btnSubmit" value="Submit Team" />
                    </div>
                </asp:panel>
            </div>
            <div class="back" style="padding-top: 15px;">
                <input type="button" id="btnNewBack" value="&lArr; Back" />
            </div>
        </div>
        <div id="viewPreviousTeam" style="display:none">
            <div class="input-append date" id="dp2" data-date-format="mm-dd-yyyy">
                <asp:panel runat="server">
                    <div id="previousSong">
                        <div style="margin-bottom: 15px;"><span>Date: </span><input class="span2" runat="server" id="txtPrevDate" size="16" type="text"></div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button runat="server" OnClientClick="ShowPrevInnerPanel();" OnClick="GetPreviousTeam" Text="Get Team for Date" />
                                    <div id="prevInner" class="previous" runat="server">
                                        <div>
                                        <h4>Songs for <span id="prevDate" runat="server"></span></h4>
                                        <asp:Panel runat="server" CssClass="pnlPrevSingers" GroupingText="Singers">
                                            <asp:BulletedList runat="server" ID="blPrevSingers"/>
                                        </asp:Panel>
                                        <asp:Panel runat="server" CssClass="pnlPrevMusicians" GroupingText="Musicians">
                                            <asp:BulletedList runat="server" ID="blPrevMusicians"/>
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
    <div class="currTeam">
        <asp:UpdatePanel runat="server" ID="upCurr">
            <Triggers>
                <asp:AsyncPostBackTrigger controlid="btnUpcoming" eventname="Click" />
            </Triggers>
            <ContentTemplate>
                <div class="upcomingInner" style="padding-left: 10px;">
                    <h4>Worship Team for the current month(<span runat="server" id="currDate"></span>):</h4>
                    <asp:Panel runat="server" CssClass="pnlCurrSingers" GroupingText="Singers">
                        <asp:BulletedList runat="server" ID="blCurrSingers"/>
                    </asp:Panel>
                    <asp:Panel runat="server" CssClass="pnlCurrMusicians" GroupingText="Musicians">
                        <asp:BulletedList runat="server" ID="blCurrMusicians"/>
                    </asp:Panel>
                    <asp:Button runat="server" ID="btnUpcoming" OnClick="UpdateUpcoming" style="display:none"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
       
    <script type="text/javascript">
       function AddMemberTxt() {
           var newItem = $("<div style='margin-top: 5px' class='teamDiv'><div style='width:300px;'><hr/></div><span>Member Name: </span><input class='teamMembers' type='text'><br /><div style='padding-top:5px'><select class='roleType'><option value='-1'>Member Role</option><option value='Singer'>Singer</option><option value='Musician'>Musician</option></select></div></div>");

           $('.memberTxts').append(newItem);

       }

       $('#btnAddTeam').click(function (e) {
           $('#addNewTeam').show();
           $('#viewPreviousTeam').hide();
           $('#wouldYou').hide();
       });
       
       $('#btnNewBack,#btnPrevBack').click(function (e) {
           $('#addNewTeam').hide();
           $('#viewPreviousTeam').hide();
           $('#wouldYou').show();
       });
       
       $('#btnViewPrevious').click(function (e) {
           $('#addNewTeam').hide();
           $('#viewPreviousTeam').show();
           $('#wouldYou').hide();
       });
       
       $('#btnSubmit').click(function (e) {
            var isValid = true;
            $('.teamMembers').each(function () {
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
            $('.roleType').each(function () {
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

           SubmitTeam();
       });

       $('.teamMembers').keyup(function () {
           $(this).css({
               "border": "",
               "background": ""
           });
           $('#success').hide();
       });

       $('.roleType').change(function () {
           if($(this).val() !== -1)
               $(this).css({
                   "border": "",
                   "background": ""
               });
           $('#success').hide();
       });
       
       function SubmitTeam() {
           var members = [];
           var date = $('#<%=txtDate.ClientID%>');

           $('.teamDiv').each(function () {
               var member = new Object();
               member.name = $(this).find('.teamMembers').val()
               member.role = $(this).find('.roleType').val();
               member.month = date.val();
               members.push(member);
           });

           members = JSON.stringify({
               'members': members
           })
           $.ajax({
               type: "POST",
               dataType: "json",
               contentType: "application/json; charset=utf-8",
               url: "WorshipTeam.aspx/SaveTeam",
               data: members,
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
                format: "mm/yyyy",
                language: "tr",
                startView: "months",
                minViewMode: "months"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
            dp.datepicker('setDate', new Date());

            var dp2 = $('#<%=txtPrevDate.ClientID%>');
            dp2.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "mm/yyyy",
                language: "tr",
                startView: "months", 
             minViewMode: "months"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
            dp2.datepicker('setDate', new Date());
        });
    </script>
</asp:Content>