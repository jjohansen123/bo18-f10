using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using BachelorDataAccess;


namespace BachelorApp
{
    class Tier
    {
        public static void TierSort()
        {
            using (var db = new BachelorContext())
            {
                //db.Nodes.Add(new Node() { Description = NodeDescription, ParentID = readParent, DirectConnectedUsers = DirectCon });
               // db.Nodes.Count
                db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Process completed");

            }
        }
    }
}