using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;
using BachelorDataAccess;


namespace BachelorApp
{
    class Tiers
    {
        public static void Tiersort()
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.Lingling == 1)
                        {
                            Tieralg(s, 0);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Tieralg(Node n, int tier)
        {
            try
            {
                n.TierID = tier + 1;
                if (n.Children == null)
                {
                    return;
                }

                if (n.Children.Count == 0)
                {
                    return;
                }
                foreach (Node s in n.Children)
                {
                    Tieralg(s, n.TierID);
                }
                return;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                Console.ReadKey();
            }
            return;
        }
    }
}