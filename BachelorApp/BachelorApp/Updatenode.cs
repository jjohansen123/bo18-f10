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
        /// <summary>
        /// Updates the node description.
        /// </summary>
        /// <param name="LocalID">The local identifier.</param>
        /// <param name="Name">The name.</param>
        /// <param name="SiteID">The site identifier.</param>
        public static void UpdateNodeDescription(int LocalID, String Name, int SiteID)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == LocalID && s.SiteId == SiteID)
                        {
                            s.Name = Name;
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
        /// <summary>
        /// Updates the node comment.
        /// </summary>
        /// <param name="LocalID">The local identifier.</param>
        /// <param name="Comment">The comment.</param>
        /// <param name="SiteID">The site identifier.</param>
        public static void UpdateNodeComment(int LocalID, String Comment, int SiteID)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == LocalID && s.SiteId == SiteID)
                        {
                            s.Comment = Comment;
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
        /// <summary>
        /// Updates the node users.
        /// </summary>
        /// <param name="LocalID">The local identifier.</param>
        /// <param name="NewDirectlyConnected">The new directly connected.</param>
        /// <param name="SiteID">The site identifier.</param>
        public static void UpdateNodeUsers(int LocalID, Int32 NewDirectlyConnected, int SiteID)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == LocalID && s.SiteId == SiteID)
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
        /// <summary>
        /// Updates the node model.
        /// </summary>
        /// <param name="LocalID">The local identifier.</param>
        /// <param name="NodeModel">The node model.</param>
        /// <param name="SiteID">The site identifier.</param>
        public static void UpdateNodeModel(int LocalID, Int32 NodeModel, int SiteID)
        {
            try
            {
                using (var db = new BachelorContext())
                {
                    List<Node> nodes = db.Nodes.ToList();
                    foreach (Node s in nodes)
                    {
                        if (s.LocalID == LocalID && s.SiteId == SiteID)
                        {
                            s.ModelId = NodeModel;
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
