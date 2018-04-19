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
        public static void AddSite(String SiteName)
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
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT MAX(SiteId) FROM DBO.Sites"), conn);
                    int HighestId = (int)cmd.ExecuteScalar() + 1;
                    
                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Sites ON"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("INSERT into dbo.Sites (SiteId,SiteName)  VALUES ( {0} , '{1}')", HighestId, SiteName), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Sites OFF"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestNodeId ON"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("INSERT into dbo.HighestNodeID (SiteId,HighestId)  VALUES ( {0} , 1)", HighestId), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestNodeId OFF"), conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        public static void RegisterNode()
        {
            Console.WriteLine("Insert new sitename");
            String SiteName = Console.ReadLine();
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


                    Console.WriteLine("New Site ID: " + HighestId);
                    

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Sites ON"), conn);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Setting Site ON");

                    cmd = new SqlCommand(string.Format("INSERT into dbo.Sites (SiteId,SiteName)  VALUES ( {0} , '{1}')", HighestId, SiteName), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Sites OFF"), conn);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Site OK");


                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestNodeId ON"), conn);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Setting Highestnode ON");

                    cmd = new SqlCommand(string.Format("INSERT into dbo.HighestNodeID (SiteId,HighestId)  VALUES ( {0} , 1)", HighestId), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestNodeId OFF"), conn);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Highest node OK");
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
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
        public static String GetSiteNoGui()
        {
            try
            {

                using (var db = new BachelorContext())
                {
                    List<Site> Sites = db.Sites.ToList();
                    foreach (Site s in Sites)
                    {
                        Console.WriteLine("Site id: " + s.SiteId + " sitename: " + s.SiteName);
                        Console.ReadKey();
                    }
                }
                return "Load error";
            }
            catch (Exception e)
            {
                throw e;
            }           
        }
    }
}
