﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace BachelorApp
{
    public class Viewsinglenodedescription
    {
        public static String ViewSingleNodeDescription(Int32 NodeID)
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
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT Description FROM dbo.Nodes WHERE NodeID = '{0}'", NodeID), conn);
                    conn.Open();
                    String Output = (String)cmd.ExecuteScalar();
                    return Output;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "error";
            }
        }
    }
}