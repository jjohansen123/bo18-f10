using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using BachelorDataAccess;

namespace BachelorApp
{
    public class Updatetotal
    {
        public static void RunUpdate(int Site)
        {
            using (var db = new BachelorContext())
            {
                try
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == 1 && s.SiteId == Site)
                        {
                            UpdateTotal(s);
                        }
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
        public static int UpdateTotal(Node n)
        {
            try
            {

                if (n.Children == null)
                {
                    n.Children = new List<Node>();
                }

                if (n.Children.Count == 0)
                {
                    n.TotalConnectedUsers = n.DirectConnectedUsers;
                    return n.DirectConnectedUsers;
                }
                int temp = 0;
                foreach (Node s in n.Children)
                {
                    temp += UpdateTotal(s);
                }
                n.TotalConnectedUsers = temp + n.DirectConnectedUsers;
                return n.TotalConnectedUsers;
            }
            catch (Exception e)
            {
                throw e;
            }

            
        }
    }
}
