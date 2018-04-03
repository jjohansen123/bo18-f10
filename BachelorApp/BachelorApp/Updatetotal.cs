using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorModel;

namespace BachelorApp
{
    class Updatetotal
    {
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
                System.Console.WriteLine(e);
            }

            return n.TotalConnectedUsers;
        }
    }
}
