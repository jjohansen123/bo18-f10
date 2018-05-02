using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using BachelorDataAccess;
using System.Data.SqlClient;

namespace BachelorApp
{
    public class Deletenode
    {
        public static void DeleteNode(Int32 LocalID, int SiteID)
        {
            try
            {
                Console.WriteLine("Node to Delete: ");
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == LocalID)
                        {
                            if (s.Children == null || s.Children.Count() == 0)
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
                                        SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM dbo.Nodes WHERE LocalID = '{0}' AND SiteID = '{1}'", LocalID, SiteID), conn);
                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                    
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
}
