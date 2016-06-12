using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Configuration;

namespace DataAccessLayer
{
    public class eccDao
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
