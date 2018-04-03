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
        public static void RefeshAll()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.NodeID == 1)
                        {
                            BachelorApp.Nullall.NullAll(s);
                            s.TotalConnectedUsers = BachelorApp.Updatetotal.UpdateTotal(s);
                            db.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
    }
}
