using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachelorModel
{
    public class Node
    {
        public int NodeID { get; set; }
        public int LocalID { get; set; }
        public int ParentID { get; set; }
        public String Name { get; set; }
        public String Comment { get; set; }
        public Int32 DirectConnectedUsers { set; get; }
        public int TotalConnectedUsers { set; get; }
        public virtual List<Node> Children { get; set; } 
        public int ModelId { get; set; }
        public int SiteId { get; set; }
        //public int temp { get; set; }
    }
}
