using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Configuration;
using Common.DataTransformationObjects;
using System.Data;
using System.Data.SqlClient;

namespace Server.DataAccessLayer
{
    public class eccDao
    {
        public List<SongDto> GetECCFiles()
        {
            List<SongDto> songList = new List<SongDto>();

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ccmusicconn"].ConnectionString))
                {
                    con.Open();

                    DataSet ds = new DataSet();
                    SqlCommand sqlComm = new SqlCommand("GetAllFileNames", con);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        songList.Add(new SongDto { Name = dr["FileName"].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return songList;
        }

        public List<SongDto> GetECCFilesForSong(string songName)
        {
            var songList = new List<SongDto>();

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ccmusicconn"].ConnectionString))
                {
                    con.Open();

                    DataSet ds = new DataSet();
                    SqlCommand sqlComm = new SqlCommand("GetFilesForName", con);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@SongName", songName);

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        songList.Add(new SongDto()
                        {
                            Name = dr["FileName"].ToString(),
                            Path = dr["FilePath"].ToString(),
                            FileType = dr["FileType"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return songList;
        }

        public void UploadSong(string fileName, string withExtension, string fileType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ccmusicconn"].ConnectionString))
                {
                    con.Open();

                    DataSet ds = new DataSet();
                    SqlCommand sqlComm = new SqlCommand("InsertFile", con);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@FileName", fileName);
                    if (fileType.Equals("1"))
                        sqlComm.Parameters.AddWithValue("@FilePath", "MusicSheets/Chords/" + withExtension);
                    else if (fileType.Equals("3"))
                        sqlComm.Parameters.AddWithValue("@FilePath", "MusicSheets/Lyrics/" + withExtension);
                    sqlComm.Parameters.AddWithValue("@FileTYpe", fileType);

                    sqlComm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public List<SongDto> GetSongsByUse(DateTime usedDate)
        {
            var songList = new List<SongDto>();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ccmusicconn"].ConnectionString))
                {
                    con.Open();

                    DataSet ds = new DataSet();
                    SqlCommand sqlComm = new SqlCommand("GetSongsByDate", con);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.Parameters.AddWithValue("@LastUsedDate", usedDate.ToShortDateString());

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        songList.Add(new SongDto()
                        {
                            Name = dr["SongName"].ToString(),
                            DateUsed = dr["DateUsed"].ToString()
                        });
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return songList;
        }
    }
}
