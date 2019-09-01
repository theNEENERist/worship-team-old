using ccmusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Server.BusinessObjects;
using Common.DataTransformationObjects;

namespace ccmusic.Controllers
{
    public class eccController : Controller
    {
        eccManager eccManager = new eccManager();

        public List<SongDto> GetECCFiles()
        {
            return eccManager.GetECCFiles();

        }

        public List<SongDto> GetEccFilesForSong(string songName)
        {
            return eccManager.GetECCFilesForSong(songName);
        }

        public void UploadSong(string fileName, string withExtension, string fileType)
        {
            eccManager.UploadSong(fileName, withExtension, fileType);
        }

        public List<Song> GetSongsByUse(DateTime usedDate)
        {
           return eccManager.GetSongsByUse(usedDate);
        }

        public void SubmitSongsForUse(List<Song> songs)
        {
            eccManager.SubmitSongsForUse(songs);
        }

        public List<Song> GetSongsForNextSunday(string sunday)
        {
            return eccManager.GetSongsForNextSunday(sunday);
        }

        public void SaveTeam(List<TeamMember> members)
        {
            eccManager.SaveTeam(members);
        }

        public List<TeamMember> GetWorshipTeam(string date)
        {
            return eccManager.GetWorshipTeam(date);
        }
    }
}