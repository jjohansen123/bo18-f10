using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;
using BachelorModel;


namespace BachelorApp
{
    class View
    {
        public static void ViewNodes()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    Console.Clear();
                    Console.WriteLine("Node information");

                    foreach (Node s in nodes)
                    {
                        if (s.Children == null)
                        {
                            s.Children = new List<Node>();
                        }
                        Console.WriteLine("Node ID: " + s.NodeID + " - Parent ID: " + s.ParentID + " - Description: " + s.Description + " - Routers connected: " + s.Children.Count + " - Users directly connected: " + s.DirectConnectedUsers + " - Total number of users: " + s.TotalConnectedUsers);
                    }
                    Console.ReadKey();
                    BachelorApp.MenuNogui.Menu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                BachelorApp.MenuNogui.Menu();
            }
        }
    }
}
