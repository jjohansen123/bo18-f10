using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BachelorApp
{
    public class ViewSingleNodeTotalConnected
    {
        public static int viewSingleNodeTotalConnected(Int32 LocalID, int SiteID)
        {
            SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(local)\SQLEXPRESS",
                InitialCatalog = "BachelorDataAccess.BachelorContext",
                IntegratedSecurity = true
            };
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=donau.hiof.no;Initial Catalog=kristei;Integrated Security=False;User ID=kristei;Password=qDW7OP;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT TotalConnectedUsers FROM dbo.Nodes WHERE LocalID = '{0}' AND SiteID = '{1}'", LocalID, SiteID), conn);
                    conn.Open();
                    int Output = (int)cmd.ExecuteScalar();
                    return Output;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
