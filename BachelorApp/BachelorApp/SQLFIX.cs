using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BachelorApp
{
    public class SQLFIX
    {
        public static void Sqlfix()
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
                    SqlCommand cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestLocalID ON"), conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(string.Format("INSERT into dbo.HighestLocalID (LocalID,Value)  VALUES ( 1 , 1)"), conn);
                    
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT HighestLocalID OFF"), conn);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        
        }
    }
}
