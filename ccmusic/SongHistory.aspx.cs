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
            dateTextBox.Value = DateTime.Now.Date.ToString();
            songs = ecc.GetECCFiles();
            var h = songs.Select(x => x.Name);
            songsJson = JsonConvert.SerializeObject(h);
        }

        protected void AddSongDDL(object sender, EventArgs e)
        {
            var ID = "songForDate" + ddlList.Count;
            /*DropDownList ddl = new DropDownList();
            ddl.CssClass = "songForDate";
            ddl.DataSource = songs;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Name";
            ddl.DataBind(); */
            TextBox txt = new TextBox();
            txt.ID = ID;
            txt.CssClass = "songForDate";
            //somePanelInsideYourForm.Controls.Add(newTextBox);

            //songListContainer.Controls.Add(ddl);
            ddlList.Add(ID);

            var results = this.Controls.OfType<DropDownList>().Where(c =>
                Convert.ToString(c.Attributes["class"]).Contains("songForDate"));

            var h = songListContainer.Controls.OfType<DropDownList>().Where(c =>
                Convert.ToString(c.Attributes["class"]).Contains("songForDate"));
        }

        protected void SubmitSongs(object sender, EventArgs e)
        {
            var date = dateTextBox.Value;
            var songs = new List<SongDto>();

            foreach (var ddl in ddlList)
            {
                var control = (DropDownList)FindControl(ddl);

                songs.Add
                (
                    new SongDto()
                    {
                        Name = control.SelectedValue
                        ,DateUsed = date
                    }
                );
            }
        }

        protected void GetSongsByDate(object sender, EventArgs e)
        {
            var songList = ecc.GetSongsByUse(DateTime.Parse(dateTextBox.Value.ToString()));

            foreach (SongDto song in songList)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv";
                createDiv.Attributes.Add("class", "col-md-3 songListOutter searchable");
                System.Web.UI.HtmlControls.HtmlGenericControl innerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.InnerHtml = "<a href='SongDetails?Name=" + song.Name + "' class='noLink' runat='server' onClick='LinkOnClick'><div class='songList'><h3>" + song.Name + "</h3></div></a>";
                songListContainer.Controls.Add(createDiv);
            }
        }
    }
}