using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.DataAccessLayer;
using Common.DataTransformationObjects;

namespace Server.BusinessObjects
{
    public class eccManager
    {
        readonly eccDao eccDao = new eccDao();

        public List<SongDto> GetECCFiles()
        {
            return eccDao.GetECCFiles();
        }

        public List<SongDto> GetECCFilesForSong(string songName)
        {
            return eccDao.GetECCFilesForSong(songName);
        }

        public void UploadSong(string fileName, string withExtension, string fileType)
        {
            eccDao.UploadSong(fileName, withExtension, fileType);
        }

        public List<Song> GetSongsByUse(DateTime usedDate)
        {
            return eccDao.GetSongsByUse(usedDate);
        }

        public void SubmitSongsForUse(List<Song> songs)
        {
            eccDao.SubmitSongsForUse(songs);
        }

        public List<Song> GetSongsForNextSunday(string sunday)
        {
            return eccDao.GetSongsForNextSunday(sunday);
        }
    }
}
