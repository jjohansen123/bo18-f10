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
        protected override void Seed(BachelorContext context)
        {
            context.Model.Add(new Options() { ModelId = 1, ModelName = "Cisco Catalyst 2960", RangeOne = 45, RangeTwo = 30 });
            context.Nodes.Add(new Node() { Description = "Top node", SiteId = 1, LocalID = 1, ParentID = 0, Children = new List<Node>(), ModelId = 1 });
            context.HighestNode.Add(new HighId() { HighestId = 1, SiteId = 1 });
            context.Sites.Add(new Site() { SiteName="Example Network" });
            base.Seed(context);
            
        }
    }
}
