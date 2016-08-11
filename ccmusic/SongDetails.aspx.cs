using ccmusic.Controllers;
using Common.DataTransformationObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ccmusic
{
    public partial class SongDetails : System.Web.UI.Page
    {
        eccController ecc = new eccController();

        protected void Page_Load(object sender, EventArgs e)
        {
            var chordCount = 0;
            var lyricCount = 0;

            string name = Request.QueryString["Name"];
            songTitle.Text = name;
            Page.Title = name + " : Music Sheets";
            List<SongDto> songFiles = ecc.GetEccFilesForSong(name);

            if (!songFiles.FirstOrDefault().DateUsed.Equals(null) && !songFiles.FirstOrDefault().DateUsed.Equals(""))
                lastUsed.Text = DateTime.Parse(songFiles.FirstOrDefault().DateUsed).ToString("MM/dd/yyyy");
            else
                lastUsed.Text = "Never!";

            foreach (SongDto song in songFiles.Where(x => x.FileType == "1"))
            {
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv";
                createDiv.Attributes.Add("class", "col-md-3 songDetailsListOuter");
                System.Web.UI.HtmlControls.HtmlGenericControl innerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.InnerHtml = "<a href='" + song.Path.ToString() + "' class='noLink' runat='server' onClick='LinkOnClick'><div class='songDetailsList'><h3>" + song.Name + " - Chords</h3></div></a>";
                //songFileList.Controls.Add(createDiv);
                chordsList.Controls.Add(createDiv);
                chordCount++;
            }

            foreach (SongDto song in songFiles.Where(x => x.FileType == "3"))
            {
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv";
                createDiv.Attributes.Add("class", "col-md-3 songDetailsListOuter");
                System.Web.UI.HtmlControls.HtmlGenericControl innerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.InnerHtml = "<a href='" + song.Path.ToString() + "' class='noLink' runat='server' onClick='LinkOnClick'><div class='songDetailsList'><h3>" + song.Name + " - Lyrics</h3></div></a>";
                //songFileList.Controls.Add(createDiv);
                lyricsList.Controls.Add(createDiv);
                lyricCount++;
            }

            if (chordCount == 0)
                chordsList.Visible = false;

            if (lyricCount == 0)
                lyricsList.Visible = false;
        }
    }
}