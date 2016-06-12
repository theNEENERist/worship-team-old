using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ccmusic.Controllers;

namespace ccmusic
{
    public partial class FileUpload : System.Web.UI.Page
    {
        eccController ecc = new eccController();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            if (upload.HasFile)
            {
                if (songType.SelectedValue.Equals("1"))
                    upload.SaveAs(Server.MapPath("MusicSheets/Chords/" + upload.FileName));
                else if (songType.SelectedValue.Equals("3"))
                    upload.SaveAs(Server.MapPath("MusicSheets/Lyrics/" + upload.FileName));

                ecc.UploadSong(fileName.Text, upload.FileName, songType.SelectedValue);
            }
        }
    }
}