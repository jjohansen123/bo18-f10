using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;

namespace BachelorApp
{
    public class Devices
    {
        /// <summary>
        /// Adds a new device to the database.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="Low">The lower parameter.</param>
        /// <param name="High">The higher parameter.</param>
        public static void Add(String name, int Low, int High)
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
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT MAX(ModelId) FROM DBO.Devices"), conn);
                    int HighestId = (int)cmd.ExecuteScalar() + 1;

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Devices ON"), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("INSERT into dbo.Devices (ModelId,ModelName,RangeOne,RangeTwo)  VALUES ( {0} , '{1}',{2},{3})", HighestId, name, Low, High), conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand(string.Format("SET IDENTITY_INSERT Sites OFF"), conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Changes the specified device.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="Low">The low.</param>
        /// <param name="High">The high.</param>
        public static void Change(int Id, String name, int Low, int High)
        {
            try
            {
                using (var db = new BachelorContext())
                {

                    List<BachelorModel.Devices> OptionsList = db.Model.ToList();
                    foreach (BachelorModel.Devices s in OptionsList)
                    {
                        if (s.ModelId == Id)
                        {
                            s.ModelName = name;
                            s.RangeOne = Low;
                            s.RangeTwo = High;
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

        /// <summary>
        /// Deletes the specified device.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public static void Delete(int Id)
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
                    SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM Dbo.Devices WHERE ModelId = '{0}'", Id), conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets a list of all devices.
        /// </summary>
        /// <returns></returns>
        public static List<BachelorModel.Devices> Get()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<BachelorModel.Devices> returnvalue = db.Model.ToList();
                    return returnvalue;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
