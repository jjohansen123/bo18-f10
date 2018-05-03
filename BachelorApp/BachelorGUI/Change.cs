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
        public static void ChangeNode(List<RadioButton> listrb, string desc, int users, int SiteID, int ModelID)
        {
            int LocalID = 1;
            foreach (RadioButton rb in listrb)
            {
                if (rb.Checked)
                {
                    if (rb.Name == "baseBtn")
                    {
                        break;
                    }
                    LocalID = Convert.ToInt32(rb.Name);
                    break;
                }
            }

            if (desc != BachelorApp.ViewsinglenodeDescription.ViewSingleNodeDescription(LocalID, SiteID))
            {
                BachelorApp.Updatenode.UpdateNodeDescription(LocalID, desc, SiteID);
            }

            if (users != BachelorApp.Viewsinglenodeconnected.ViewSingleNodeConnected(LocalID, SiteID))
            {
                BachelorApp.Updatenode.UpdateNodeUsers(LocalID, users, SiteID);
            }
        }
    }
}
