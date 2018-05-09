using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;
using BachelorModel;
using System.Data.SqlClient;

namespace BachelorApp
{
    public class SiteFunctions
    {
        /// <summary>
        /// Registers a new site.
        /// </summary>
        /// <param name="SiteName">Name of the site.</param>
        public static void AddSite(String SiteName)
        {
            string commentText = "Color coding:" + "\n" +
            "Red = High amounts of users." + "\n" +
            "Yellow = Medium to high amounts of users." + "\n" +
            "Green = Good amounts of users." + "\n" +
            "Blue = No users." + "\n" +
            "\n" +
            "The \"%\" values on the nodes, describe where the load is higher" + "\n" +
            "\n" +
            "Double clicking on a node opens up the \"Change Nodes\" window." + "\n";

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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT MAX(SiteId) FROM DBO.Sites"), conn);
                    int HighestId = (int)cmd.ExecuteScalar() + 1;
                    cmd = new SqlCommand(string.Format("SELECT MAX(NodeId) FROM DBO.Nodes"), conn);
                    int HighestNodeId = (int)cmd.ExecuteScalar() + 1;

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Sites ON"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("INSERT into dbo.Sites (SiteId,SiteName)  VALUES ( {0} , '{1}')", HighestId, SiteName), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Sites OFF"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestLocalID ON"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("INSERT into dbo.HighestLocalID (SiteId,HighestId)  VALUES ( {0} , 1)", HighestId), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestLocalID OFF"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Nodes ON"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("INSERT into dbo.Nodes ( SiteId, LocalID, Name, DirectConnectedUsers, ParentID, TotalConnectedUsers, NodeID, ModelId, Comment)  VALUES ( {0} , {1}, '{2}', {3}, {4}, {5}, {6}, {7}, '{8}')", HighestId, 1, "Internet Connection", 0, 0, 0, HighestNodeId, 1,commentText), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Nodes OFF"), conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        /// <summary>
        /// Gets a list of all sites.
        /// </summary>
        /// <returns></returns>
        public static List<Site> GetSite()
        {
            try
            {

                using (var db = new BachelorContext())
                {
                    List<Site> Sites = db.Sites.ToList();

                    return Sites;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes the site.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public static void DeleteSite(int Id)
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
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM Dbo.Sites WHERE SiteId = '{0}'", Id), conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(string.Format("DELETE FROM Dbo.HighestLocalId WHERE SiteId = '{0}'", Id), conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(string.Format("DELETE FROM Dbo.Nodes WHERE SiteId = '{0}'", Id), conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
