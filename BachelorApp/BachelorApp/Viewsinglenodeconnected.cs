using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BachelorApp
{
    public class Viewsinglenodeconnected
    {
        public static int ViewSingleNodeConnected(Int32 NodeID)
        {
            SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(local)\SQLEXPRESS",
                InitialCatalog = "BachelorDataAccess.BachelorContext",
                IntegratedSecurity = true
            };
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = BachelorDataAccess.BachelorContext; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT DirectConnectedUsers FROM dbo.Nodes WHERE NodeID = '{0}'", NodeID), conn);
                    conn.Open();
                    int Output = (int)cmd.ExecuteScalar();
                    return Output;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
    }
}
