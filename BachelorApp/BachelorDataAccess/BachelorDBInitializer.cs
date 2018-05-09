using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BachelorModel;
using System.Data.SqlClient;
using System.Configuration;

namespace BachelorDataAccess
{
    class BachelorDBInitializer : DropCreateDatabaseIfModelChanges<BachelorContext>
    {
        string commentText = "Color coding:" + "\n" +
            "Red = High amounts of users." + "\n" +
            "Yellow = Medium to high amounts of users." + "\n" +
            "Green = Good amounts of users." + "\n" +
            "Blue = No users." + "\n" +
            "\n" +
            "The \"%\" values on the nodes, describe where the load is higher" + "\n" +
            "\n" +
            "Double clicking on a node opens up the \"Change Nodes\" window." + "\n";
        protected override void Seed(BachelorContext context)
        {
            context.Model.Add(new Devices() { ModelId = 1, ModelName = "Cisco Catalyst 2960", RangeOne = 45, RangeTwo = 30 });
            context.Nodes.Add(new Node() { Name = "Internet Connection", Comment =commentText, SiteId = 1, LocalID = 1, ParentID = 0, Children = new List<Node>(), ModelId = 1 });
            context.HighestNode.Add(new HighId() { HighestId = 1, SiteId = 1 });
            context.Sites.Add(new Site() { SiteName="Example Network" });
            base.Seed(context);
            
        }
    }
}
