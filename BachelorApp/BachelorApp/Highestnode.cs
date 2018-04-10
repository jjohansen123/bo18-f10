using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using System.Data.Sql;
using BachelorDataAccess;

namespace BachelorApp
{
    public class Highestnode
    {
        public static void PrintHighest()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<HighestID> highest = db.HighID.ToList();
                    foreach (HighestID s in highest)
                    {
                        Console.WriteLine("Highest ID in database: " + s.Value);
                        Console.ReadKey();
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static int GetHighest()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<HighestID> highest = db.HighID.ToList();
                    foreach (HighestID s in highest)
                    {
                       return s.Value;
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }   
        }
    }
}
