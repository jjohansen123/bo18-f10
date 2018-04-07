using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachelorGUI
{
    class Change
    {
        public static void ChangeNode(List<RadioButton> listrb, string desc, int users)
        {
            int nodeID = 1;
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    if (rb.Name == "baseBtn")
                    {
                        break;
                    }
                    nodeID = Convert.ToInt32(rb.Name);
                    break;
                }
            }

            if (desc != BachelorApp.Viewsinglenodedescription.ViewSingleNodeDescription(nodeID))
            {
                BachelorApp.Updatenode.UpdateNodeDescription(nodeID, desc);
            }

            if (users != BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(nodeID))
            {
                BachelorApp.Updatenode.UpdateNodeUsers(nodeID, users);
            }
        }
    }
}
