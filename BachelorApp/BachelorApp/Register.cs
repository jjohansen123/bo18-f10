using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using BachelorDataAccess;

namespace BachelorApp
{
    public class Register
    {
        public static void RegisterNode()
        {
            try
            {

                Console.WriteLine("Insert description:");
                string NodeDescription = Console.ReadLine();
                Console.WriteLine("Insert parent ID:");
                Int32 readParent = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Insert directly connected users:");
                Int32 DirectCon = Int32.Parse(Console.ReadLine());

                
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();

                    List<HighestID> Highscore = db.HighID.ToList();
                    foreach (HighestID s in Highscore)
                    {
                        s.Value++;
                        Console.WriteLine("Highest node is now: " + s.Value);
                        db.SaveChanges();
                    }
                    foreach (Node s in nodes)
                    {
                        s.TotalConnectedUsers = 0;
                        if (s.NodeID == readParent)
                        {
                            if (s.Children == null)
                            {
                                s.Children = new List<Node>();
                            }
                            s.Children.Add(new Node() { Description = NodeDescription, ParentID = readParent, DirectConnectedUsers = DirectCon, Children = new List<Node>() });
                            db.SaveChanges();
                            Tiers.Tiersort();
                        }
                    }
                    foreach (Node s in nodes)
                    {
                        if (s.NodeID == 1)
                        {
                            BachelorApp.Nullall.NullAll(s);
                            s.TotalConnectedUsers = BachelorApp.Updatetotal.UpdateTotal(s);
                            db.SaveChanges();
                        }
                    
                    }
                    
                    BachelorApp.MenuNogui.Menu();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        
        public static void RegisterNode(string NodeDescription, Int32 readParent, Int32 DirectCon)
        {
            try
            {

                Console.WriteLine("Insert description:");
                Console.WriteLine("Insert parent ID:");
                Console.WriteLine("Insert directly connected users:");


                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        s.TotalConnectedUsers = 0;
                        if (s.NodeID == readParent)
                        {
                            if (s.Children == null)
                            {
                                s.Children = new List<Node>();
                            }
                            s.Children.Add(new Node() { Description = NodeDescription, ParentID = readParent, DirectConnectedUsers = DirectCon, Children = new List<Node>() });
                            db.SaveChanges();
                            Tiers.Tiersort();

                        }
                    }
                    foreach (Node s in nodes)
                    {
                        if (s.NodeID == 1)
                        {
                            BachelorApp.Nullall.NullAll(s);
                            s.TotalConnectedUsers = BachelorApp.Updatetotal.UpdateTotal(s);
                            db.SaveChanges();
                        }
                    }
                    List<HighestID> Highscore = db.HighID.ToList();
                    foreach (HighestID s in Highscore)
                    {
                        s.NodeID++;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        } 
    }
}
