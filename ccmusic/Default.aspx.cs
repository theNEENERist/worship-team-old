using ccmusic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.DataTransformationObjects;

namespace ccmusic
{
    public partial class _Default : Page
    {
        eccController ecc = new eccController();

        protected void Page_Load(object sender, EventArgs e)
        {
            var songList = ecc.GetECCFiles();

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