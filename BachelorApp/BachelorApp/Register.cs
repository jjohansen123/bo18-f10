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

        /// <summary>
        /// Registers the node.
        /// </summary>
        /// <param name="NodeDescription">The node description.</param>
        /// <param name="NodeComment">The node comment.</param>
        /// <param name="readParent">The read parent.</param>
        /// <param name="DirectCon">The direct con.</param>
        /// <param name="site">The site.</param>
        /// <param name="model">The model.</param>
        public static void RegisterNode(string NodeDescription, string NodeComment, Int32 readParent, Int32 DirectCon, int site, int model)
        { 
            try
            {
                
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                       
                        if (s.LocalID == readParent && s.SiteId == site)
                        {
                            s.TotalConnectedUsers = 0;
                            if (s.Children == null)
                            {
                                s.Children = new List<Node>();
                            }
                            s.Children.Add(new Node() { Name = NodeDescription,Comment = NodeComment, ParentID = readParent, LocalID = Highestnode.GetHighest(site) +1, DirectConnectedUsers = DirectCon, Children = new List<Node>(), SiteId = site , ModelId = model});
                            db.SaveChanges();
                            Highestnode.SetHighest(site);
                        }
                    }
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == 1 && s.SiteId == site)
                        {
                            
                            s.TotalConnectedUsers = BachelorApp.Updatetotal.UpdateTotal(s);
                            db.SaveChanges();
                        }
                    }
                
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
    }
}
