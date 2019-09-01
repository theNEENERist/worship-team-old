using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ccmusic
{
    using Controllers;

    public partial class ModifySongs : System.Web.UI.Page
    {
        eccController ecc = new eccController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GetSongsByUse(object sender, EventArgs e)
        {
            var songs = ecc.GetSongsByUse(DateTime.Parse(txtDate.Value.ToString()));
            songs = songs.OrderBy(i => i.type == "Closing").
                ThenBy(i => i.type == "Invitation").
                ThenBy(i => i.type == "Communion").
                ThenBy(i => i.type == "Worship").ToList();
            gvModifyList.DataSource = songs;
            gvModifyList.DataBind();
        }
    }
}