using ccmusic.Controllers;
using Common.DataTransformationObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ccmusic
{
    public partial class SongHistory : System.Web.UI.Page
    {
        eccController ecc = new eccController();
        public List<SongDto> songs;
        public string songsJson;
        List<string> ddlList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now.Date.ToString();
            songs = ecc.GetECCFiles();
            var h = songs.Select(x => x.Name);
            songsJson = JsonConvert.SerializeObject(h);
            GetSongsForSunday();
        }

        [System.Web.Services.WebMethod]
        public static void SaveSongs(List<Song> songs)
        {
            eccController ecc1 = new eccController();
            ecc1.SubmitSongsForUse(songs);
        }

        protected void GetSongsForSunday()
        {
            var sunday = ((int)DayOfWeek.Sunday- (int)DateTime.Today.DayOfWeek + 7) % 7;
            DateTime nextSunday = DateTime.Today.AddDays(sunday);

            eccController ecc1 = new eccController();
            var songs = ecc1.GetSongsForNextSunday(nextSunday.ToString("MM/dd/yyyy"));

            nextDate.InnerText = nextSunday.ToString("MM/dd/yyyy");

            var worshipSongs = songs.Where(s => s.type == "Worship");
            var communionSongs = songs.Where(s => s.type == "Communion");
            var invitationSongs = songs.Where(s => s.type == "Invitation");
            var closingSongs = songs.Where(s => s.type == "Closing");

            if(worshipSongs.Count() > 0)
                blWorship.DisplayMode = BulletedListDisplayMode.HyperLink;
            if (communionSongs.Count() > 0)
                blCommunion.DisplayMode = BulletedListDisplayMode.HyperLink;
            if (invitationSongs.Count() > 0)
                blInvitation.DisplayMode = BulletedListDisplayMode.HyperLink;
            if (closingSongs.Count() > 0)
                blClosing.DisplayMode = BulletedListDisplayMode.HyperLink;

            blWorship.Items.Clear();
            blCommunion.Items.Clear();
            blInvitation.Items.Clear();
            blClosing.Items.Clear();

            if (worshipSongs.Count() > 0)
            {
                foreach (Song song in worshipSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name;
                    li.Text = song.name;  
                    blWorship.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blWorship);
            }

            if (communionSongs.Count() > 0)
            {
                foreach (Song song in communionSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name; ;  
                    li.Text = song.name;  
                    blCommunion.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blCommunion);
            }

            if (invitationSongs.Count() > 0)
            {
                foreach (Song song in invitationSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name;
                    li.Text = song.name;  
                    blInvitation.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blInvitation);
            }

            if (closingSongs.Count() > 0)
            {
                foreach (Song song in closingSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name;
                    li.Text = song.name;  
                    blClosing.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blClosing);
            }
        }

        private void AddNoSongsLI(BulletedList bl)
        {
            ListItem li = new ListItem();
            li.Value = "No songs chosen for this section";
            li.Text = "No songs chosen for this section";
            li.Attributes.Add("style", "Color: Red");
            bl.Items.Add(li);
        }

        protected void UpdateUpcoming(object sender, EventArgs e)
        {
            GetSongsForSunday();
            
        }

        protected void GetSongsByUse(object sender, EventArgs e)
        {
            var songs = ecc.GetSongsByUse(DateTime.Parse(txtPrevDate.Value.ToString()));
            prevDate.InnerText = txtPrevDate.Value.ToString();

            var worshipSongs = songs.Where(s => s.type == "Worship");
            var communionSongs = songs.Where(s => s.type == "Communion");
            var invitationSongs = songs.Where(s => s.type == "Invitation");
            var closingSongs = songs.Where(s => s.type == "Closing");

            if (worshipSongs.Count() > 0)
                blPrevWorship.DisplayMode = BulletedListDisplayMode.HyperLink;
            if (communionSongs.Count() > 0)
                blPrevCommunion.DisplayMode = BulletedListDisplayMode.HyperLink;
            if (invitationSongs.Count() > 0)
                blPrevInvitation.DisplayMode = BulletedListDisplayMode.HyperLink;
            if (closingSongs.Count() > 0)
                blPrevClosing.DisplayMode = BulletedListDisplayMode.HyperLink;

            blPrevWorship.Items.Clear();
            blPrevCommunion.Items.Clear();
            blPrevInvitation.Items.Clear();
            blPrevClosing.Items.Clear();

            if (worshipSongs.Count() > 0)
            {
                foreach (Song song in worshipSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name;
                    li.Text = song.name;
                    blPrevWorship.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blPrevWorship);
            }

            if (communionSongs.Count() > 0)
            {
                foreach (Song song in communionSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name;
                    li.Text = song.name;
                    blPrevCommunion.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blPrevCommunion);
            }

            if (invitationSongs.Count() > 0)
            {
                foreach (Song song in invitationSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name;
                    li.Text = song.name;
                    blPrevInvitation.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blPrevInvitation);
            }

            if (closingSongs.Count() > 0)
            {
                foreach (Song song in closingSongs)
                {
                    ListItem li = new ListItem();
                    li.Value = "/SongDetails?Name=" + song.name;
                    li.Text = song.name;
                    blPrevClosing.Items.Add(li);
                }
            }
            else
            {
                AddNoSongsLI(blPrevClosing);
            }

            prevInner.Attributes.Add("style", "display:block");
        }
        
        /*protected void GetSongsByDate(object sender, EventArgs e)
        {
            var songList = ecc.GetSongsByUse(DateTime.Parse(txtDate.Value.ToString()));

            foreach (SongDto song in songList)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv";
                createDiv.Attributes.Add("class", "col-md-3 songListOutter searchable");
                System.Web.UI.HtmlControls.HtmlGenericControl innerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.InnerHtml = "<a href='SongDetails?Name=" + song.Name + "' class='noLink' runat='server' onClick='LinkOnClick'><div class='songList'><h3>" + song.Name + "</h3></div></a>";
                songListContainer.Controls.Add(createDiv);
            }
        }*/
    }
}