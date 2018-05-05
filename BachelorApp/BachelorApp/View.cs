using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorDataAccess;
using BachelorModel;


namespace BachelorApp
{
    public class View
    {
        
        public static List<Node> ViewNodesList(int SiteID)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    List<Node> returnList = new List<Node>();
                    foreach(Node n in nodes)
                    {
                        if(n.SiteId == SiteID)
                        {
                            returnList.Add(n);
                        }
                    }
                    return returnList;
                }
            }

            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
