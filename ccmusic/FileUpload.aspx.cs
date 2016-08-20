using System;
using ccmusic.Controllers;
using Common;

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

                CacheLayer.Remove("songs");
            }
        }
    }
}