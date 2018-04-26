using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;
using BachelorModel;

namespace BachelorApp
{
    public class Updatenode
    {
        public static void UpdateNode()
        {
            try
            {
                Console.WriteLine("Node to edit: ");
                Int32 Lingling = Int32.Parse(Console.ReadLine());

                using (var db = new BachelorContext())
                {
                    Console.WriteLine("What do you want to edit?\n1: Description\n2: Directly connected users");
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.Lingling == Lingling)
                        {

                            Int32 Option = Int32.Parse(Console.ReadLine());
                            if (Option == 1)
                            {
                                Console.WriteLine("Insert new description");
                                String newDescription = Console.ReadLine();
                                s.Description = newDescription;
                            }
                            else if (Option == 2)
                            {
                                Console.WriteLine("Insert directly connected users");
                                Int32 NewDirectlyConnected = Int32.Parse(Console.ReadLine());
                                s.DirectConnectedUsers = NewDirectlyConnected;
                            }
                            else
                            {
                                Console.WriteLine("No node found");
                                Console.ReadKey();
                            }
                            db.SaveChanges();


                        }
                    }
                    BachelorApp.Refreshall.RefeshAll();
                    BachelorApp.MenuNogui.Menu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }

        public static void UpdateNodeDescription(int Lingling, String newDescription)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.Lingling == Lingling)
                        {
                            s.Description = newDescription;
                            db.SaveChanges();
                        }
                    }
                    BachelorApp.Refreshall.RefeshAll();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void UpdateNodeUsers(int Lingling, Int32 NewDirectlyConnected)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.Lingling == Lingling)
                        {
                            s.DirectConnectedUsers = NewDirectlyConnected;
                            db.SaveChanges();
                        }
                    }
                    BachelorApp.Refreshall.RefeshAll();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
