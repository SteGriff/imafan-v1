using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Events.Data
{
    public class ConnectionTest
    {
        public void Connect()
        {
            Debug.WriteLine("Testing SQL connection...");
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                Debug.WriteLine(conn.ServerVersion);
            }
            Debug.WriteLine(connectionString);
        }
    }
}
