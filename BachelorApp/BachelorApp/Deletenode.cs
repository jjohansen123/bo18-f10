using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using BachelorDataAccess;
using System.Data.SqlClient;

/// <summary>
/// This function takes in a local ID and site ID to delete a spesific done from the database.
/// </summary>
namespace BachelorApp
{
    public class Deletenode
    {

        public static void DeleteNode(Int32 LocalID, int SiteID)
        {

            SqlConnectionStringBuilder connStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(local)\SQLEXPRESS",
                InitialCatalog = "BachelorDataAccess.BachelorContext",
                IntegratedSecurity = true
            };

            using (SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = BachelorDataAccess.BachelorContext; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM dbo.Nodes WHERE LocalID = '{0}' AND SiteID = '{1}'", LocalID, SiteID), conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == 1 && s.SiteId == SiteID)
                        {
                            s.TotalConnectedUsers = BachelorApp.Updatetotal.UpdateTotal(s);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}