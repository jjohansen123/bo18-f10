using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BachelorApp
{
    public class ViewSingleNodeParent
    {
        /// <summary>
        /// Returns the id of the nodes parent.
        /// </summary>
        /// <param name="LocalID">The local identifier.</param>
        /// <param name="SiteID">The site identifier.</param>
        /// <returns></returns>
        public static int ViewSingleParent(Int32 LocalID, int SiteID)
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
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT ParentID FROM dbo.Nodes WHERE LocalID = '{0}' AND SiteID = '{1}'", LocalID, SiteID), conn);
                    conn.Open();
                    int Output= (int)cmd.ExecuteScalar();
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
