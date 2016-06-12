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
                /*using (OdbcConnection con = new OdbcConnection(ConfigurationManager.ConnectionStrings["ccmusicconn"].ConnectionString))
                using (OdbcCommand command = con.CreateCommand())
                {
                    command.CommandText = "{call GetAllFileNames()}";
                    command.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();

                    con.Open();

                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        songList.Add(new SongDto() { Name = row["name"].ToString() });
                    }

                    con.Close();              
                }*/

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
            List<SongDto> songList = new List<SongDto>();

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
                /*using (OdbcCommand command = con.CreateCommand())
                {
                    command.CommandText = "{call GetFilesForName('" + songName + "')}";
                    command.Parameters.AddWithValue("@name", songName);
                    command.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();

                    con.Open();

                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        songList.Add(new SongDto()
                            {
                                Name = row["name"].ToString(),
                                Path = row["path"].ToString()
                            });
                    }
                    con.Close();
                }*/
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


                    /*using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["ccmusicconn"].ConnectionString))
                    {
                        connection.Open();
                        using (OdbcCommand command = new OdbcCommand("insert into `musicFiles` values('" + fileName + "', 'MusicSheets/" + withExtension + "','1')", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }*/
                    //}

                    sqlComm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
