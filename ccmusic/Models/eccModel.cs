using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace ccmusic.Models
{
    public class eccModel
    {
        public void GetECCFiles()
        {
            try
            {
                string music;
                using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["ccmusicconn"].ConnectionString))
                {
                    connection.Open();
                    using (OdbcCommand command = new OdbcCommand("SELECT * FROM `ecc`", connection))
                    using (OdbcDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                            music = (dr["path"].ToString());
                        dr.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}