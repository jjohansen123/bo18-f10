using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BachelorModel
{
    public class Node
    {
        public int NodeID { get; set; }
        public int Lingling { get; set; }
        public int ParentID { get; set; }
        public String Description { get; set; }
        public Int32 DirectConnectedUsers { set; get; }
        public int TotalConnectedUsers { set; get; }
        public virtual List<Node> Children { get; set; } 
        public int TierID { get; set; }
        public int SiteId { get; set; }
        //public int temp { get; set; }
    }
}
