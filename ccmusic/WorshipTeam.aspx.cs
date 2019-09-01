using ccmusic.Controllers;
using Common.DataTransformationObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ccmusic
{
    public partial class WorshipTeam : System.Web.UI.Page
    {
        eccController ecc = new eccController();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Value = DateTime.Now.Date.ToString();
            GetCurrentTeam();
        }

        [System.Web.Services.WebMethod]
        public static void SaveTeam(List<TeamMember> members)
        {
            eccController ecc1 = new eccController();
            ecc1.SaveTeam(members);
        }

        protected void UpdateUpcoming(object sender, EventArgs e)
        {
            GetCurrentTeam();

        }

        protected void GetCurrentTeam()
        {
            eccController ecc1 = new eccController();
            var members = ecc1.GetWorshipTeam(DateTime.Now.ToString("MM/yyyy"));

            currDate.InnerText = DateTime.Now.ToString("MM/yyyy");

            var singers = members.Where(s => s.Role == "Singer");
            var musicians = members.Where(s => s.Role == "Musician");

            blCurrSingers.Items.Clear();
            blCurrMusicians.Items.Clear();

            if (singers.Count() > 0)
            {
                foreach (TeamMember singer in singers)
                {
                    ListItem li = new ListItem();
                    li.Value = singer.Name;
                    li.Text = singer.Name;
                    blCurrSingers.Items.Add(li);
                }
            }
            else
            {
                AddNoMembersLi(blCurrSingers, "singers");
            }

            if (musicians.Count() > 0)
            {
                foreach (TeamMember musician in musicians)
                {
                    ListItem li = new ListItem();
                    li.Value = musician.Name;
                    li.Text = musician.Name;
                    blCurrMusicians.Items.Add(li);
                }
            }
            else
            {
                AddNoMembersLi(blCurrMusicians, "musicians");
            }

            //currDate.InnerText = nextSunday.ToString("MM/dd/yyyy");

            /* var worshipSongs = songs.Where(s => s.type == "Worship");
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
             }*/
        }

        private void AddNoMembersLi(BulletedList bl, string role)
        {
            ListItem li = new ListItem();
            li.Value = "No " + role + " chosen";
            li.Text = "No " + role + " chosen";
            li.Attributes.Add("style", "Color: Red");
            bl.Items.Add(li);
        }

        protected void GetPreviousTeam(object sender, EventArgs e)
        {
            var members = ecc.GetWorshipTeam(DateTime.Parse(txtPrevDate.Value.ToString()).ToString("MM/yyyy"));
            prevDate.InnerText = txtPrevDate.Value.ToString();


            var singers = members.Where(s => s.Role == "Singer");
            var musicians = members.Where(s => s.Role == "Musician");

            blPrevSingers.Items.Clear();
            blPrevMusicians.Items.Clear();

            if (singers.Count() > 0)
            {
                foreach (TeamMember singer in singers)
                {
                    ListItem li = new ListItem();
                    li.Value = singer.Name;
                    li.Text = singer.Name;
                    blPrevSingers.Items.Add(li);
                }
            }
            else
            {
                AddNoMembersLi(blPrevSingers, "singers");
            }

            if (musicians.Count() > 0)
            {
                foreach (TeamMember musician in musicians)
                {
                    ListItem li = new ListItem();
                    li.Value = musician.Name;
                    li.Text = musician.Name;
                    blPrevMusicians.Items.Add(li);
                }
            }
            else
            {
                AddNoMembersLi(blPrevMusicians, "musicians");
            }

            prevInner.Attributes.Add("style", "display:block");
        }
    }
}