using BachelorDataAccess;
using BachelorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorApp
{
    public class ViewSingleNodeChildren
    {
        public static List<Node> ViewChildren(Int32 ID, int SiteID)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach(Node n in nodes)
                    {
                        if(n.LocalID == ID && n.SiteId == SiteID)
                        {
                            return n.Children;
                        }
                    }
                    return null;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
