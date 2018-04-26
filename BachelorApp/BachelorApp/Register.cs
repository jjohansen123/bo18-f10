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

                    List<HighId> Highscore = db.HighestNode.ToList();
                    foreach (HighId s in Highscore)
                    {
                        s.HighestId++;
                        Console.WriteLine("Highest node is now: " + s.HighestId);
                        db.SaveChanges();
                    }
                    foreach (Node s in nodes)
                    {
                        s.TotalConnectedUsers = 0;
                        if (s.LocalID == readParent)
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
                        if (s.LocalID == 1)
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

        
        public static void RegisterNode(string NodeDescription, Int32 readParent, Int32 DirectCon, int site)
        { //SE HER MARTIN TODO: DROPDOWN MENU SOM BESTEMMER SITE, REEEE!
            try
            {
                
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        s.TotalConnectedUsers = 0;
                        if (s.LocalID == readParent)
                        {
                            if (s.Children == null)
                            {
                                s.Children = new List<Node>();
                            }
                            s.Children.Add(new Node() { Description = NodeDescription, ParentID = readParent, LocalID = Highestnode.GetHighest(site) +1, DirectConnectedUsers = DirectCon, Children = new List<Node>(), SiteId = site });
                            db.SaveChanges();
                           // Tiers.Tiersort();
                            Highestnode.SetHighest(site);
                        }
                    }
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == 1)
                        {
                            BachelorApp.Nullall.NullAll(s);
                            s.TotalConnectedUsers = BachelorApp.Updatetotal.UpdateTotal(s);
                            db.SaveChanges();
                        }
                    }
                    /*List<HighId> Highscore = db.HighestNode.ToList();
                    foreach (HighId s in Highscore)
                    {
                        s.HighestId++;
                        db.SaveChanges();
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        } 
    }
}
