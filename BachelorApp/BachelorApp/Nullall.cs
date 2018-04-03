using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;

namespace BachelorApp
{
    class Nullall
    {
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
    }
}
