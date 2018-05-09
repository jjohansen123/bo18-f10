using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;
using BachelorModel;

namespace BachelorApp
{
    class Refreshall
    {
        /// <summary>
        /// A helper function to refresh all nodes total connected users.
        /// </summary>
        public static void RefeshAll()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == 1)
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
