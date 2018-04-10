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

            context.Nodes.Add(new Node() { Description = "Top node", ParentID = 0, Children = new List<Node>() });
            context.HighID.Add(new HighestID() { NodeID = 1, Value = 1 });
            base.Seed(context);

            //BachelorApp.SQLFIX.Sqlfix();
        }
    }
}
