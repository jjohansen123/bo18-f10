using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;
using BachelorModel;

namespace BachelorApp
{


    class Program
    {

        public static void RecursiveDelete(Node s)
        {

            if(s.Children == null || s.Children.Count() == 0)
            {
                s = null;
                return;
            }
            else
            {
                foreach(Node n in s.Children)
                {
                    RecursiveDelete(n);
                }
            }
            s = null;
        }


        public static void UpdateNode()
        {
            try
            {
                Console.WriteLine("Node to edit: ");
                Int32 NodeID = Int32.Parse(Console.ReadLine());

                using (var db = new BachelorContext())
                {
                    Console.WriteLine("What do you want to edit?\n1: Description\n2: Directly connected users");
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.NodeID == NodeID)
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

                    Menu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
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
                            NullAll(s);
                            s.TotalConnectedUsers = UpdateTotal(s);
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
        public static int UpdateTotal(Node n)
        {
            try
            {
                
                if(n.Children == null)
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
            catch(Exception e)
            {
                System.Console.WriteLine(e);
            }
           
            return n.TotalConnectedUsers;
        }

        public static void NullAll(Node n)
        {
            try
            {

                if (n.Children == null)
                {
                    n.Children = new List<Node>();
                }
                n.TotalConnectedUsers = 0;
                if (n.Children.Count != 0)
                {
                    foreach (Node s in n.Children)
                    {
                        n.TotalConnectedUsers = 0;
                        NullAll(s);
                    }

                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
 
        }
        public static void Register()
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
                    foreach (Node s in nodes)
                    {
                        s.TotalConnectedUsers = 0;
                        if (s.NodeID == readParent)
                        {
                            if (s.Children == null)
                            {
                                s.Children = new List<Node>();
                            }
                            
                            //Console.WriteLine("Node ID: " + s.NodeID + " - Description: " + s.Description + " - Routers connected: " + s.Children.Count + " - Users directly connected: " + s.DirectConnectedUsers + " - Total number of users: " + s.TotalConnectedUsers + " - Parent ID: " + s.ParentID);
                            
                            // db.Nodes.Add(new Node() { Description = NodeDescription, ParentID = readParent, DirectConnectedUsers = DirectCon, Children = new List<Node>() });
                            s.Children.Add(new Node() { Description = NodeDescription, ParentID = readParent, DirectConnectedUsers = DirectCon, Children = new List<Node>() });
                            db.SaveChanges();
                            Console.Clear();
                            Console.WriteLine("Process completed");
                            
                        }
                    }
                    foreach( Node s in nodes)
                    {
                        if (s.NodeID == 1)
                        {
                            NullAll(s);
                            s.TotalConnectedUsers = UpdateTotal(s);
                            db.SaveChanges();
                        }
                    }
                    Menu();
                    /*--------------------------
                    db.Nodes.Add(new Node() { Description = NodeDescription, ParentID = readParent, DirectConnectedUsers = DirectCon, Children = new List<Node>() });
                    db.SaveChanges();
                    Console.Clear();
                    Console.WriteLine("Process completed");
                    Menu();
                    */
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Unable to comply. Press any key to return to menu.");
                Console.ReadKey();
                Menu();
            }
        }

        public static void View()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    Console.Clear();
                    Console.WriteLine("Node information");

                    //var i = from db 

                    foreach (Node s in nodes) {
                        if (s.Children == null)
                        {
                            s.Children = new List<Node>();
                        }
                        Console.WriteLine("Node ID: " + s.NodeID + " - Parent ID: " + s.ParentID + " - Description: " + s.Description + " - Routers connected: " + s.Children.Count + " - Users directly connected: " + s.DirectConnectedUsers + " - Total number of users: " + s.TotalConnectedUsers );
                    }
                    /*
                List<Course> courses = db.Courses.ToList();
                Console.WriteLine("\nCourses:\n");
                foreach (Course cor in courses)
                    Console.WriteLine(cor.CourseID + " - " + cor.CourseName);

                Console.WriteLine("\n Enter the number of the student, press enter, then the number of the course:");
                int StudNr = Int32.Parse(Console.ReadLine());
                int CouNr = Int32.Parse(Console.ReadLine());

                Course c = db.Courses.First(e => e.CourseID == CouNr);

                if (c != null)
                {
                    Student s = db.Students.First(i => i.StudentID == StudNr);
                    if (s != null)
                    {
                        if (s.Courses == null)
                            s.Courses = new List<Course>();
                        s.Courses.Add(c);

                        if (c.Students == null)
                            c.Students = new List<Student>();
                        c.Students.Add(s);

                Data Source=|DataDirectory|BachelorDataAccess.BachelorContext.sdf; 

                        db.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("Process completed");
                        Menu();
                    }
                }
                */
                    Console.ReadKey();
                    Menu();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                Menu();
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Options:\n[1]: Add node to system\n[2]: View Nodes\n[3]: Edit node\n[4]: Delete node(and all its children)\n[Anything else] Exit");
            ConsoleKey ButtonPressed = Console.ReadKey().Key;
            Console.Clear();
            if (ButtonPressed == ConsoleKey.D1 || ButtonPressed == ConsoleKey.NumPad1 || ButtonPressed == ConsoleKey.End)
            {
                Register();
            }
            else if (ButtonPressed == ConsoleKey.D2 || ButtonPressed == ConsoleKey.NumPad2 || ButtonPressed == ConsoleKey.DownArrow)
            {
                View();
            }
            else if (ButtonPressed == ConsoleKey.D3 || ButtonPressed == ConsoleKey.NumPad3 || ButtonPressed == ConsoleKey.PageDown)
            {
                UpdateNode();
            }
            else if (ButtonPressed == ConsoleKey.D4 || ButtonPressed == ConsoleKey.NumPad4 || ButtonPressed == ConsoleKey.PageDown)
            {
                Console.WriteLine("Insert ID of node to delete");
                Int32 DeleteNode = Int32.Parse(Console.ReadLine());
                try
                {
                    using (var db = new BachelorContext())
                    {
                        List<Node> nodes = db.Nodes.ToList();
                        foreach (Node s in nodes)
                        {
                            if (s.NodeID == DeleteNode)
                            {
                                RecursiveDelete(s);
                                db.SaveChanges();
                                Menu();
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
            else
            {
                Console.WriteLine("Exiting");
                Console.ReadKey();
            }

            }
        
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
